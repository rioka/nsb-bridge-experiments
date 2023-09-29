/* left */
SELECT 'LeftSender queue on Right'
  ,[Id]
  ,[CorrelationId]
  ,[ReplyToAddress]
  ,[Recoverable]
  ,[Expires]
  ,[Headers]
  ,[Body]
  ,[RowVersion]
FROM 
  [Samples.Bridges.Right].[dbo].[LeftSender];

SELECT 'RightReceiver queue on Right'
  ,[Id]
  ,[CorrelationId]
  ,[ReplyToAddress]
  ,[Recoverable]
  ,[Expires]
  ,[Headers]
  ,[Body]
  ,[RowVersion]
FROM
  [Samples.Bridges.Right].[dbo].[RightReceiver];

SELECT 'TopReceiver queue on Right'
  ,[Id]
  ,[CorrelationId]
  ,[ReplyToAddress]
  ,[Recoverable]
  ,[Expires]
  ,[Headers]
  ,[Body]
  ,[RowVersion]
FROM
  [Samples.Bridges.Right].[dbo].[TopReceiver];

SELECT 'SubscriptionRouting on Right'
  ,*
FROM 
  [Samples.Bridges.Right].[dbo].[SubscriptionRouting];

