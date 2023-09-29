/* left */
SELECT 'LeftSender queue on Left'
  ,[Id]
  ,[CorrelationId]
  ,[ReplyToAddress]
  ,[Recoverable]
  ,[Expires]
  ,[Headers]
  ,[Body]
  ,[RowVersion]
FROM 
  [Samples.Bridges.Left].[dbo].[LeftSender];

SELECT 'LeftReceiver queue on Left'
  ,[Id]
  ,[CorrelationId]
  ,[ReplyToAddress]
  ,[Recoverable]
  ,[Expires]
  ,[Headers]
  ,[Body]
  ,[RowVersion]
FROM
  [Samples.Bridges.Left].[dbo].[LeftReceiver];

SELECT 'RightReceiver queue on Left'
  ,[Id]
  ,[CorrelationId]
  ,[ReplyToAddress]
  ,[Recoverable]
  ,[Expires]
  ,[Headers]
  ,[Body]
  ,[RowVersion]
FROM
  [Samples.Bridges.Left].[dbo].[RightReceiver];

SELECT 'TopReceiver queue on Left'
  ,[Id]
  ,[CorrelationId]
  ,[ReplyToAddress]
  ,[Recoverable]
  ,[Expires]
  ,[Headers]
  ,[Body]
  ,[RowVersion]
FROM
  [Samples.Bridges.Left].[dbo].[TopReceiver];

SELECT 'SubscriptionRouting on Left'
  ,*
FROM 
  [Samples.Bridges.Left].[dbo].[SubscriptionRouting];

