Use master
Go
Create Database MST
Go
Use MST
Go
Create Table [Role](
	Id Uniqueidentifier primary key,
	Name varchar(256) not null,
	Description nvarchar(max)
)
Go
Create Table [Address](
	Id Uniqueidentifier primary key,
	City nvarchar(256) not null,
	District nvarchar(256) not null,
	Street nvarchar(256) not null,
	ApartmentNumber nvarchar(256),
)
Go
Create Table [User](
	Id Uniqueidentifier primary key,
	Username varchar(256) unique not null,
	Email nvarchar(256) unique not null,
	Password nvarchar(256) not null,
	AvatarUrl varchar(max),
	FirstName nvarchar(256),
	LastName nvarchar(266),
	AddressId Uniqueidentifier foreign key references [Address](Id),
	Status bit,
)
Go
Create Table Wallet(
	Id Uniqueidentifier primary key,
	UserId  Uniqueidentifier foreign key references [User](Id),
	Balance float not null default 0,
)
Go
Create Table [Transaction](
	Id Uniqueidentifier primary key,
	WalletId  Uniqueidentifier foreign key references Wallet(Id),
	Description nvarchar(max) not null,
	Transform float not null,
)
Go
Create Table UserRole(
	UserId Uniqueidentifier foreign key references [User](Id),
	RoleId Uniqueidentifier foreign key references [Role](Id),
	Description nvarchar(max),
	Primary key (UserId, RoleId)
)
Go
Create Table Lecture(
	Id Uniqueidentifier primary key,
	FirstName nvarchar(256),
	LastName nvarchar(266),
	AvatarUrl varchar(max),
	GenderId Uniqueidentifier foreign key references Gender(Id),
	Bio nvarchar(max),
	Price float not null,
	Status bit,
)
Go
Create Table Document(
	Id Uniqueidentifier primary key,
	Name nvarchar(256) not null,
	Description nvarchar(max),
	Url nvarchar(max) not null,
	Status bit default 1,
)
Go
Create Table LectureDocument(
	LectureId Uniqueidentifier foreign key references Lecture(Id),
	DocumentId Uniqueidentifier foreign key references Document(Id),
	Description nvarchar(max),
	Primary key (LectureId, DocumentId)
)
Go
Create Table Gender(
	Id Uniqueidentifier primary key,
	Name nvarchar(256) not null,
)
Go
Create Table Feedback(
	Id Uniqueidentifier primary key,
	UserId Uniqueidentifier foreign key references [User](Id),
	LectureId Uniqueidentifier foreign key references Lecture(Id),
	Content nvarchar(max),
	Star float not null,
)
Go
Create Table Grade (
	Id Uniqueidentifier primary key,
	Name nvarchar(266) not null,
	Description nvarchar(max),
)
Go
Create Table LectureGrade(
	LectureId Uniqueidentifier foreign key references Lecture(Id),
	GradeId Uniqueidentifier foreign key references Grade(Id),
	Description nvarchar(max),
	Primary key (LectureId, GradeId)
)
Go
Create Table [Subject](
	Id Uniqueidentifier primary key,
	Name nvarchar(266) not null,
	Description nvarchar(max),
)
Go
Create Table LectureSubject (
	LectureId Uniqueidentifier foreign key references Lecture(Id),
	SubjectId Uniqueidentifier foreign key references [Subject](Id),
	Description nvarchar(max),
	Primary key (LectureId, SubjectId)
)
Go
Create Table Syllabus (
	Id Uniqueidentifier primary key,
	Name nvarchar(256) not null,
	Status bit not null default 1,
)
Go
Create Table GradeSyllabus (
	GradeId Uniqueidentifier foreign key references Grade(Id),
	SyllabusId Uniqueidentifier foreign key references Syllabus(Id),
	Ratio float not null default 1,
	Primary key (GradeId, SyllabusId)
)
Go
Create Table Demand(
	Id Uniqueidentifier primary key,
	GradeId Uniqueidentifier foreign key references Grade(Id) not null,
	SubjectId Uniqueidentifier foreign key references [Subject](Id) not null,
	SyllabusId Uniqueidentifier foreign key references Syllabus(Id) not null,
	GenderId Uniqueidentifier foreign key references Gender(Id),
)
Go
Create Table BookingStatus(
	Id Uniqueidentifier primary key,
	Name nvarchar(256) not null,
	Description nvarchar(max),
)
Go
Create Table Payment(
	Id Uniqueidentifier primary key,
	Fee float not null, 
	IsPayment bit default 0,
	Description nvarchar(max),
)
Go
Create Table [Booking](
	Id Uniqueidentifier primary key,
	LectureId Uniqueidentifier foreign key references [Lecture](Id),
	UserId Uniqueidentifier foreign key references [User](Id),
	PaymentId Uniqueidentifier foreign key references Payment(Id),
	BookingAt datetime default getdate(),
	BookingStatusId Uniqueidentifier foreign key references BookingStatus(Id),
)
Go
Create Table Promotion(
	Id Uniqueidentifier primary key,
	Name nvarchar(256),
	Description nvarchar(max),
	CreateDate datetime default getdate(),
	Ratio float not null,
)
Go
Create Table [Event](
	Id Uniqueidentifier primary key,
	Name nvarchar(256),
	Thumbnail nvarchar(max),
	Description nvarchar(max),
	CreateDate datetime default getdate(),
	PromotionId Uniqueidentifier foreign key references Promotion(Id),
	StartDate datetime default getdate(),
	EndDate datetime not null,
)
Go
Create Table UserEvent(
	EventId Uniqueidentifier foreign key references [Event](Id),
	UserId Uniqueidentifier foreign key references [User](Id),
	Primary key (EventId, UserId)
)
Go
Create Table Slot(
	Id Uniqueidentifier primary key,
	StartTime datetime not null,
	EndTime datetime not null,
)
Go
Create Table Schedule(
	Id Uniqueidentifier primary key,
	SlotId Uniqueidentifier foreign key references Slot(Id) not null,
	SubjectId Uniqueidentifier foreign key references [Subject](Id) not null,
	UserId Uniqueidentifier foreign key references [User](Id) not null,
	LectureId Uniqueidentifier foreign key references Lecture(Id) not null
)