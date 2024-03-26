CREATE DATABASE Test01
---------------------------------------------------------
USE Test01
---------------------------------------------------------
CREATE TABLE [dbo].[Employee_Info](
	[EmployeeID] [int] NOT NULL,
	[FirstName] [varchar](20) NOT NULL,
	[LastName] [varchar](20) NOT NULL,
	[Address] [varchar](500) NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[PassportNo] [int] NULL,
	[DOB] [varchar](50) NOT NULL,
	[ContactNo] [int] NOT NULL,
	[MonthlySalary] [float] NOT NULL,
	[OTRateHourly] [float] NOT NULL,
	[Allowance] [float] NOT NULL,
	[GovTaxRate] [float] NOT NULL,
 CONSTRAINT [PK_Employee_Info] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

---------------------------------------------------------

CREATE TABLE [dbo].[Login_Info](
	[Username] [varchar](25) NOT NULL,
	[Password] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Login_Info] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

---------------------------------------------------------

CREATE TABLE [dbo].[Salary_Info](
	[SalaryID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[PaymentDate] [varchar](50) NOT NULL,
	[BaseSalary] [float] NOT NULL,
	[OT] [float] NOT NULL,
	[NoPay] [float] NOT NULL,
	[GrossPay] [float] NOT NULL,
 CONSTRAINT [PK_Salary_Info] PRIMARY KEY CLUSTERED 
(
	[SalaryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

---------------------------------------------------------

CREATE TABLE [dbo].[Settings](
	[SalaryCycleStartDate] [varchar](50) NOT NULL,
	[SalaryCycleEndDate] [varchar](50) NOT NULL,
	[NoOfLeavesForAYear] [int] NOT NULL,
	[DateRange] [int] NOT NULL
) ON [PRIMARY]

