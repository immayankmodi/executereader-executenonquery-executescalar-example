--Creating 'SubjectDetails' table
CREATE TABLE [dbo].[SubjectDetails](
[SubjectId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
[SubjectName] [nvarchar](100) NULL) 

--Inserting records to 'SubjectDetails' table
INSERT INTO [SubjectDetails] ([SubjectName]) VALUES ('Asp.net')
INSERT INTO [SubjectDetails] ([SubjectName]) VALUES ('C#')
INSERT INTO [SubjectDetails] ([SubjectName]) VALUES ('Vb.net')
