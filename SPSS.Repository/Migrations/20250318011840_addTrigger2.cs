using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPSS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addTrigger2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR ALTER TRIGGER trg_UpdateOrderTotals
                ON OrderItems
                AFTER INSERT, UPDATE, DELETE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    UPDATE o
                    SET 
                        o.ItemsCount = (SELECT COUNT(*) FROM OrderItems oi WHERE oi.OrderId = o.Id),
                        o.TotalAmount = (SELECT COALESCE(SUM(oi.TotalPrice), 0) FROM OrderItems oi WHERE oi.OrderId = o.Id)
                    FROM Orders o
                    WHERE o.Id IN (
                        SELECT DISTINCT OrderId FROM inserted
                        UNION
                        SELECT DISTINCT OrderId FROM deleted
                    );
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS [dbo].[trg_UpdateOrderTotals];");
        }
    }
}
