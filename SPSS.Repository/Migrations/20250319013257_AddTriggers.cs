using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPSS.Repository.Migrations
{
    public partial class AddTriggers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR ALTER TRIGGER trg_UpdateCartTotalPrice
                ON CartItems
                AFTER INSERT, UPDATE, DELETE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    UPDATE CI
                    SET CI.TotalPrice = COALESCE(P.Price * CI.Quantity, 0)
                    FROM CartItems CI
                    INNER JOIN Products P ON CI.ProductId = P.Id;

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

                    UPDATE C
                    SET C.ItemsCount = 0, C.TotalAmount = 0
                    FROM Carts C
                    WHERE NOT EXISTS (SELECT 1 FROM CartItems CI WHERE CI.CartId = C.Id);
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE OR ALTER TRIGGER trg_UpdateProductPromotion
                ON Products
                AFTER INSERT, UPDATE, DELETE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    UPDATE p
                    SET p.Price = COALESCE(p.OriginalPrice * (100 - pm.DiscountValue) / 100, 0)
                    FROM Products p, Promotions pm
                    WHERE p.PromotionId = pm.Id;
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE OR ALTER TRIGGER trg_UpdateOrderPromotion
                ON Orders
                AFTER UPDATE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    IF UPDATE(PromotionId)
                    BEGIN
                        UPDATE o
                        SET 
                            o.TotalAmount = COALESCE(
                                (SELECT COALESCE(SUM(oi.TotalPrice), 0) FROM OrderItems oi WHERE oi.OrderId = o.Id) * (100 - COALESCE(pm.DiscountValue, 0)) / 100, 
                                (SELECT COALESCE(SUM(oi.TotalPrice), 0) FROM OrderItems oi WHERE oi.OrderId = o.Id)
                            )
                        FROM Orders o
                        LEFT JOIN Promotions pm ON o.PromotionId = pm.Id
                        WHERE o.Id IN (SELECT DISTINCT Id FROM inserted);
                    END;
                END;
            ");

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
                        o.OriginalTotalAmount = (SELECT COALESCE(SUM(p.OriginalPrice * oi.Quantity), 0) 
                                                 FROM OrderItems oi
                                                 JOIN Products p ON oi.ProductId = p.Id
                                                 WHERE oi.OrderId = o.Id),
                        o.TotalAmount = COALESCE((SELECT COALESCE(SUM(oi.TotalPrice), 0) FROM OrderItems oi WHERE oi.OrderId = o.Id), 0)
                    FROM Orders o
                    LEFT JOIN Promotions pm ON o.PromotionId = pm.Id
                    WHERE o.Id IN (
                        SELECT DISTINCT OrderId FROM inserted
                        UNION
                        SELECT DISTINCT OrderId FROM deleted
                    );
                END;
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_UpdateCartTotalPrice;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_UpdateProductPromotion;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_UpdateOrderPromotion;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_UpdateOrderTotals;");
        }
    }
}
