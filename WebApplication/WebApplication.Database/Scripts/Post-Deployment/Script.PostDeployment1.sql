/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\LoadDataScripts\aspnet_Applications_Insert.sql	
:r .\LoadDataScripts\aspnet_SchemaVersions_Insert.sql	
:r .\LoadDataScripts\Client_Insert.sql	
:r .\LoadDataScripts\Location_Insert.sql	
:r .\LoadDataScripts\MenuGroup_Insert.sql	
:r .\LoadDataScripts\Recipe_Insert.sql	
:r .\LoadDataScripts\RecipeNutritional_Insert.sql
:r .\LoadDataScripts\InsertEPSAccounts.sql	
/*
 .\LoadDataScripts\Product_Insert.sql
 */
:r .\LoadDataScripts\LiveTile_Insert.sql
:r .\LoadDataScripts\DataGroup_Insert.sql
:r .\LoadDataScripts\GroupItemData_Insert.sql


