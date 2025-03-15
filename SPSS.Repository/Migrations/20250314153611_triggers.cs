using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPSS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class triggers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE or alter TRIGGER trg_UpdateCartTotalPrice
            ON CartItems
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;

                -- Update the total amount and item count in the Cart table
                UPDATE Ci
	            SET Ci.TotalPrice = COALESCE((
		            SELECT SUM(CiSub.Quantity * P.Price)
		            FROM CartItems CiSub
		            INNER JOIN Products P ON CiSub.ProductId = P.Id
		            WHERE CiSub.Id = Ci.Id
	            ), 0)
	            FROM CartItems Ci;

	            UPDATE C
                SET 
                    C.ItemsCount = COALESCE(ItemCount,0),
		            C.TotalAmount = COALESCE(TotalPrice,0)
                FROM Carts C
	            INNER JOIN (
                    SELECT CartId, COUNT(Id) AS ItemCount, Sum(TotalPrice) As TotalPrice
                    FROM CartItems
                    GROUP BY CartId
                ) Ci ON C.Id = CI.CartId;
            END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_UpdateCartTotalPrice;");
        }
    }
}
