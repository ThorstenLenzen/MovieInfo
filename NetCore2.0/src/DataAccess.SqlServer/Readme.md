﻿To Scaffold use:
dotnet ef dbcontext scaffold "Server=(localdb)\mssqllocaldb; Database=MovieInfoData; Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -c MovieInfoContext -o Data --startup-project "..\TestConsole"