using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPSS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTrigger : Migration
    {
        /// <inheritdoc />
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_UpdateCartTotalPrice
            ON CartItems
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;

                -- Update TotalPrice for each CartItem using Product Price
                UPDATE CI
                SET CI.TotalPrice = COALESCE(P.Price * CI.Quantity, 0)
                FROM CartItems CI
                INNER JOIN Products P ON CI.ProductId = P.Id;

                -- Update the Carts table to reflect the total values
                UPDATE C
                SET 
                    C.ItemsCount = COALESCE(CI.ItemCount, 0),
                    C.TotalAmount = COALESCE(CI.TotalPrice, 0)
                FROM Carts C
                LEFT JOIN (
                    SELECT CartId, COUNT(CI.Id) AS ItemCount, SUM(Quantity * P.Price) AS TotalPrice
                    FROM CartItems CI
                    INNER JOIN Products P ON CI.ProductId = P.Id
                    GROUP BY CartId
                ) CI ON C.Id = CI.CartId;

                -- Ensure carts with no items are reset to zero
                UPDATE C
                SET C.ItemsCount = 0, C.TotalAmount = 0
                FROM Carts C
                WHERE NOT EXISTS (SELECT 1 FROM CartItems CI WHERE CI.CartId = C.Id);
            END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_UpdateCartTotalPrice;");
        }

    }
}
