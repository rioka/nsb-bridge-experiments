/* top */
SELECT 'LeftSender queue on Top'
  ,[Id]
  ,[CorrelationId]
  ,[ReplyToAddress]
  ,[Recoverable]
  ,[Expires]
  ,[Headers]
  ,[Body]
  ,[RowVersion]
FROM 
  [Samples.Bridges.Top].[dbo].[LeftSender];

SELECT 'RightReceiver queue on Top'
   ,[Id]
   ,[CorrelationId]
   ,[ReplyToAddress]
   ,[Recoverable]
   ,[Expires]
   ,[Headers]
   ,[Body]
   ,[RowVersion]
FROM
    [Samples.Bridges.Top].[dbo].[RightReceiver];

SELECT 'TopReceiver queue on Top'
   ,[Id]
   ,[CorrelationId]
   ,[ReplyToAddress]
   ,[Recoverable]
   ,[Expires]
   ,[Headers]
   ,[Body]
   ,[RowVersion]
FROM
    [Samples.Bridges.Top].[dbo].[TopReceiver];

SELECT 'SubscriptionRouting on Top'
  ,*
FROM 
  [Samples.Bridges.Top].[dbo].[SubscriptionRouting];

