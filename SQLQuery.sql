USE [MST]
GO

SELECT [Id]
      ,[Username]
      ,[Email]
      ,[Password]
      ,[AvatarUrl]
      ,[FirstName]
      ,[LastName]
      ,[AddressId]
      ,[Status]
  FROM [dbo].[User]

GO

USE [MST]
GO

SELECT [Id]
      ,[City]
      ,[District]
      ,[Street]
      ,[ApartmentNumber]
  FROM [dbo].[Address]

GO

USE [MST]
GO

SELECT [Id]
      ,[City]
      ,[District]
      ,[Street]
      ,[ApartmentNumber]
  FROM [dbo].[Address]

GO

USE [MST]
GO

SELECT [UserId]
      ,[RoleId]
      ,[Description]
  FROM [dbo].[UserRole]

GO

USE [MST]
GO

SELECT [Id]
      ,[Name]
      ,[Description]
  FROM [dbo].[Role]

GO






