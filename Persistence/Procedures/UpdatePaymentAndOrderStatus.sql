USE [Store]
GO
/****** Object:  StoredProcedure [dbo].[UpdatePaymentAndOrderStatus]    Script Date: 06.10.2023 12:51:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UpdatePaymentAndOrderStatus]
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CurrentTime DATETIME;
    SET @CurrentTime = GETDATE();

    UPDATE payments
    SET Status = 20
    WHERE Status = 21 AND DATEDIFF(HOUR, Created, @CurrentTime) >= 24;

    UPDATE orders
    SET Status = 10
    WHERE Id IN (SELECT p.OrderId
                 FROM payments p
                 WHERE p.Status = 20);
END;
