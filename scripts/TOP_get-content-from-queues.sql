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
  [Samples.Bridge.Top].[dbo].[Samples.Bridge.LeftSender];

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
    [Samples.Bridge.Top].[dbo].[Samples.Bridge.RightReceiver];

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
  [Samples.Bridge.Top].[dbo].[Samples.Bridge.TopReceiver];

SELECT 'SubscriptionRouting on Top'
  ,*
FROM 
  [Samples.Bridge.Top].[dbo].[SubscriptionRouting];
