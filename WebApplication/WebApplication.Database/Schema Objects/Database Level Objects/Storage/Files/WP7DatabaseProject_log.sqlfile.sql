﻿ALTER DATABASE [$(DatabaseName)]
    ADD LOG FILE (NAME = [WP7DatabaseProject_log], FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DEV_BUILD_log.ldf', SIZE = 1792 KB, MAXSIZE = 2097152 MB, FILEGROWTH = 10 %);

