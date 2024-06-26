USE [ReportingSystem]
GO
/****** Object:  UserDefinedFunction [dbo].[getBrigadeName]    Script Date: 2/4/2024 8:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Function [dbo].[getBrigadeName]
	(@BdeID int )
	  returns nvarchar(50)
	 begin
		            return (select dbo.Brigade.BrigadeName from dbo.Brigade
		 where Brigade.ID= @BdeID)
	  end 
GO
/****** Object:  UserDefinedFunction [dbo].[getCoyName]    Script Date: 2/4/2024 8:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Function [dbo].[getCoyName]
	(@CoyID int )
	  returns nvarchar(50)
	  begin
	          return (select  [dbo].[Coy].[CoyName] from [dbo].[Coy]
	         where Coy.ID= @CoyID)
	 end 
GO
/****** Object:  UserDefinedFunction [dbo].[GetSoldiersWithinCoy]    Script Date: 2/4/2024 8:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[GetSoldiersWithinCoy]()
	returns @SoldierCoyDetail TABLE 
	(Rank nvarchar(15), Name nvarchar(50), 
	Brigade nvarchar(50),unit nvarchar(30),Company nvarchar(50))
	As
	Begin
	INSERT INTO @SoldierCoyDetail
select [dbo].[Rank].RankName as[Rank], concat([dbo].[SoldierInfo].[FName],' ',[dbo].[SoldierInfo].[LName])as [Name],  [dbo].[Brigade].[BrigadeName]as [Brigade],[dbo].[Unit].UnitName as [Unit],dbo.[Coy].CoyName as [Company]
from [dbo].[P2OEntry],[dbo].[Rank],[dbo].[Unit],[dbo].[Coy],[dbo].[SoldierInfo],[dbo].[Brigade]
	where [dbo].[Unit].Id=[dbo].[Coy].UnitID
	and dbo.[Rank].id=[dbo].[P2OEntry].RankID
	and dbo.[coy].ID = [dbo].[P2OEntry].CoyID
	and [dbo].[SoldierInfo].ID=[dbo].[P2OEntry].[RegNo]
	and [dbo].[Brigade].ID=[dbo].[Unit].[BdeID]
	order by dbo.[Coy].CoyName  
                                  Return
End
GO
/****** Object:  UserDefinedFunction [dbo].[GetSoldiersWithP2OEntry]    Script Date: 2/4/2024 8:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[GetSoldiersWithP2OEntry]()
    returns @SoldierWithP2OEntry TABLE 
     (Rank nvarchar(15), Name nvarchar(50), 
                   Brigade nvarchar(50),unit nvarchar(30),Company nvarchar(50),
                   Occurrence nvarchar(max))
	as
	Begin
                INSERT INTO @SoldierWithP2OEntry
	  select [dbo].[Rank].RankName as[Rank], concat([dbo].[SoldierInfo].[FName],' ',[dbo].[SoldierInfo].[LName])as [Name],  [dbo].[Brigade].[BrigadeName]as [Brigade],[dbo].[Unit].UnitName as [Unit],dbo.[Coy].CoyName as [Company],			  [dbo].[P2OEntry].[Occurrence]
	from [dbo].[P2OEntry],[dbo].[Rank],[dbo].[Unit],[dbo].[Coy],[dbo].[SoldierInfo],[dbo].[Brigade]
		where [dbo].[Unit].Id=[dbo].[Coy].UnitID
		   and dbo.[Rank].id=[dbo].[P2OEntry].RankID
	                and dbo.[coy].ID = [dbo].[P2OEntry].CoyID
		  and [dbo].[SoldierInfo].ID=[dbo].[P2OEntry].[RegNo]
		  and [dbo].[Brigade].ID=[dbo].[Unit].[BdeID]
         return
         End
GO
/****** Object:  Table [dbo].[Brigade]    Script Date: 2/4/2024 8:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brigade](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BrigadeName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 2/4/2024 8:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UnitName] [nvarchar](50) NOT NULL,
	[BdeID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coy]    Script Date: 2/4/2024 8:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coy](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CoyName] [nvarchar](50) NOT NULL,
	[UnitID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[countbdeCoy]    Script Date: 2/4/2024 8:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[countbdeCoy]
    (@bdeID int)

    returns table
    as
      return
         select distinct([dbo].[Unit].[UnitName]), count([dbo].[Coy].id) as [No Of Coy]
     	           from [dbo].[Brigade],[dbo].[Coy],[dbo].[Unit]
              where [dbo].[Brigade].ID =[dbo].[Unit].BdeID
                  and [dbo].[Unit].ID=[dbo].[Coy].UnitID
                  and [dbo].[Brigade].ID=@bdeID
           group by  [dbo].[Unit].[UnitName]
GO
/****** Object:  UserDefinedFunction [dbo].[countbdeUnit]    Script Date: 2/4/2024 8:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[countbdeUnit]
	 (@bdeID int)

	 returns table
	  as
	   return
	 select distinct([dbo].[brigade].[brigadeName]), count([dbo].[Unit].id) as [No Of Unit]
	   from [dbo].[Brigade],[dbo].[Unit]
     		  where [dbo].[Brigade].ID =[dbo].[Unit].BdeID
	  and [dbo].[Brigade].ID=@bdeID
	  group by  [dbo].[brigade].[brigadeName]
GO
/****** Object:  Table [dbo].[Employee_Audit_Test]    Script Date: 2/4/2024 8:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_Audit_Test](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Audit_Action] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntryType]    Script Date: 2/4/2024 8:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntryType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EntryName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdersType]    Script Date: 2/4/2024 8:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrdersName] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[P2OEntry]    Script Date: 2/4/2024 8:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[P2OEntry](
	[RegNo] [int] NOT NULL,
	[RankId] [int] NOT NULL,
	[UnitID] [int] NOT NULL,
	[CoyID] [int] NOT NULL,
	[EntryID] [int] NOT NULL,
	[OrdersID] [int] NOT NULL,
	[OrderNumber] [nvarchar](6) NOT NULL,
	[DateofOrder] [date] NOT NULL,
	[Occurrence] [nvarchar](max) NOT NULL,
	[wefDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[EnteredBy] [nvarchar](20) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Password]    Script Date: 2/4/2024 8:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Password](
	[UserName] [nvarchar](50) NOT NULL,
	[UserPassword] [nvarchar](50) NOT NULL,
	[Rights] [nvarchar](50) NOT NULL,
	[BrigadeLevel] [int] NULL,
	[UntLevel] [int] NULL,
	[CoyLevel] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rank]    Script Date: 2/4/2024 8:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rank](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RankName] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SoldierInfo]    Script Date: 2/4/2024 8:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoldierInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FName] [nvarchar](20) NOT NULL,
	[LName] [nvarchar](20) NOT NULL,
	[MaritalStatus] [nvarchar](15) NOT NULL,
	[DOB] [date] NOT NULL,
	[DOE] [date] NOT NULL,
	[ROD] [date] NOT NULL,
	[Address] [nvarchar](300) NOT NULL,
	[Parish] [nvarchar](20) NOT NULL,
	[TerminationDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Coy]  WITH CHECK ADD FOREIGN KEY([UnitID])
REFERENCES [dbo].[Unit] ([ID])
GO
ALTER TABLE [dbo].[P2OEntry]  WITH CHECK ADD FOREIGN KEY([CoyID])
REFERENCES [dbo].[Coy] ([ID])
GO
ALTER TABLE [dbo].[P2OEntry]  WITH CHECK ADD FOREIGN KEY([EntryID])
REFERENCES [dbo].[EntryType] ([Id])
GO
ALTER TABLE [dbo].[P2OEntry]  WITH CHECK ADD FOREIGN KEY([OrdersID])
REFERENCES [dbo].[OrdersType] ([Id])
GO
ALTER TABLE [dbo].[P2OEntry]  WITH CHECK ADD FOREIGN KEY([RankId])
REFERENCES [dbo].[Rank] ([Id])
GO
ALTER TABLE [dbo].[P2OEntry]  WITH CHECK ADD FOREIGN KEY([RegNo])
REFERENCES [dbo].[SoldierInfo] ([Id])
GO
ALTER TABLE [dbo].[P2OEntry]  WITH CHECK ADD FOREIGN KEY([UnitID])
REFERENCES [dbo].[Unit] ([ID])
GO
ALTER TABLE [dbo].[Unit]  WITH CHECK ADD FOREIGN KEY([BdeID])
REFERENCES [dbo].[Brigade] ([ID])
GO
/****** Object:  StoredProcedure [dbo].[sp_CountUnit]    Script Date: 2/4/2024 8:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[sp_CountUnit]
(@bdeID int)
as
declare 
   @unitCount as int

select @unitCount=COUNT(*) from Unit,Brigade
where Brigade.ID=Unit.BdeID
and Brigade.ID=@bdeID

select  'Total Unit'= @unitCount 
GO
/****** Object:  StoredProcedure [dbo].[sp_CountUnitdefault]    Script Date: 2/4/2024 8:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_CountUnitdefault]
(@bdeID int=3)
as
declare 
   @unitCount as int

select @unitCount=COUNT(*) from Unit,Brigade
where Brigade.ID=Unit.BdeID
and Brigade.ID=@bdeID
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertBrigade]    Script Date: 2/4/2024 8:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_InsertBrigade]
(
      @brigadeName nvarchar(50)
)
AS
BEGIN
    SET NOCOUNT ON
    INSERT INTO dbo.Brigade(BrigadeName)values(@brigadeName)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertEntryName]    Script Date: 2/4/2024 8:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_InsertEntryName]
(
      @EntryName nvarchar(50)
)
AS
BEGIN
    SET NOCOUNT ON
    INSERT INTO dbo.EntryType(EntryName)values(@EntryName)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_selectBrigade]    Script Date: 2/4/2024 8:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Willard Welch>
-- Create date: <February 3 2024,,>
-- Description:	<select Brigade Id and Brigade from Brigade table>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectBrigade]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT  [ID],[BrigadeName] from [dbo].[Brigade]
END 
GO
/****** Object:  StoredProcedure [dbo].[sp_selectCoy]    Script Date: 2/4/2024 8:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Willard Welch>
-- Create date: <Feb 3 2024>
-- Description:	<getting units from brigade table>
-- =============================================

CREATE PROCEDURE [dbo].[sp_selectCoy]
   @BdeID int,
   @unitId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [dbo].[Coy].[ID],[dbo].[Coy].CoyName  from [dbo].[Coy], [dbo].[Unit],[dbo].[Brigade]
	where [dbo].[Brigade].[ID]=[dbo].[Unit].[BdeID]
	and [dbo].[Brigade].[ID]=@BdeID and [dbo].[Unit].ID=[dbo].[Coy].ID
	and [dbo].[Unit].ID = @unitId
END 
GO
/****** Object:  StoredProcedure [dbo].[sp_selectUnit]    Script Date: 2/4/2024 8:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Willard Welch>
-- Create date: <Feb 3 2024>
-- Description:	<getting units from brigade table>
-- =============================================

CREATE PROCEDURE [dbo].[sp_selectUnit]
   @BdeID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT  [dbo].[Unit].[ID],[dbo].[Unit].[UnitName] from [dbo].[Unit],[dbo].[Brigade]
	where [dbo].[Brigade].[ID]=[dbo].[Unit].[BdeID]
	and [dbo].[Brigade].[ID]=@BdeID
	order by [dbo].[Unit].[UnitName]
END
GO
