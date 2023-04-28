# Proiect C#

In order for the application to work properly, you need to Restore bookify.bak to your SSMS.<br>
To do that, copy bookify.bak to the Backup folder from your installation path (usually C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\Backup).<br>
From SSMS right click on Databases -> Restore Database...<br>
From Source select Device, then click on the 3 dots to browse. In the open window, select File from Backup media type, then click on the Add button.<br>
Browse for the Backup folder mentioned before, click on bookify.bak and then click OK. Hit OK again and again on Restore Database window.<br>
After this process, you can run the app successfully.
