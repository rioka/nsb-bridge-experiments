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
  [Samples.Bridge.Right].[dbo].[Samples.Bridge.LeftSender];

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
  [Samples.Bridge.Right].[dbo].[Samples.Bridge.RightReceiver];

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
  [Samples.Bridge.Right].[dbo].[Samples.Bridge.TopReceiver];

SELECT 'SubscriptionRouting on Right'
  ,*
FROM 
  [Samples.Bridge.Right].[dbo].[SubscriptionRouting];
