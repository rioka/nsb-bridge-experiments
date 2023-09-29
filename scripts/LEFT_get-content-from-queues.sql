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
  [Samples.Bridge.Left].[dbo].[Samples.Bridge.LeftSender];

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
  [Samples.Bridge.Left].[dbo].[Samples.Bridge.LeftReceiver];

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
  [Samples.Bridge.Left].[dbo].[Samples.Bridge.RightReceiver];

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
  [Samples.Bridge.Left].[dbo].[Samples.Bridge.TopReceiver];

SELECT 'SubscriptionRouting on Left'
  ,*
FROM 
  [Samples.Bridge.Left].[dbo].[SubscriptionRouting];
