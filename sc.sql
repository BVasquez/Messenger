USE [MessengerDatabase]
GO

create trigger trig_user_default
on UserViewModels
after insert
as
begin
	insert into PersonalizationViewModels([User], [PhotoProfile], [PhotoBackground], [Color], [Status], [TextColor], [ConnectionStatus])
	values ((select top 1 UserId from UserViewModels order by UserId desc), 'defaultProfile.png', 'Comple_default_header.png', '#7fd5f5', 'Hello everybody I am using TBT Live Messenger','black', 'Online')
end
GO


INSERT [dbo].[UserViewModels] ([FirstName], [LastName], [NickName], [Gender], [DateOfBirth], [Country], [Email], [Password]) VALUES (N'Bryan', N'Vasquez', N'BVasquez', N'Male', CAST(0x000086EA00000000 AS DateTime), N'Dominican Republic', N'bvasquez@gmail.com', N'123')
INSERT [dbo].[UserViewModels] ([FirstName], [LastName], [NickName], [Gender], [DateOfBirth], [Country], [Email], [Password]) VALUES (N'Lisandro', N'Marte', N'LMarte', N'Male', CAST(0x000086EA00000000 AS DateTime), N'Dominican Republic', N'lmarte@gmail.com', N'123')
INSERT [dbo].[UserViewModels] ([FirstName], [LastName], [NickName], [Gender], [DateOfBirth], [Country], [Email], [Password]) VALUES (N'Jeison', N'Flores', N'JFA', N'Male', CAST(0x0000867300000000 AS DateTime), N'Dubai', N'jflores@gmail.com', N'123')
INSERT [dbo].[UserViewModels] ([FirstName], [LastName], [NickName], [Gender], [DateOfBirth], [Country], [Email], [Password]) VALUES (N'Carmen', N'Joaquin', N'CJoaquin', N'Female', CAST(0x0000875700000000 AS DateTime), N'Spain', N'cjoaquin@gmail.com', N'123')
INSERT [dbo].[UserViewModels] ([FirstName], [LastName], [NickName], [Gender], [DateOfBirth], [Country], [Email], [Password]) VALUES (N'Massiel', N'Perez', N'MPerez', N'Female', CAST(0x00008EB000000000 AS DateTime), N'USA', N'mperez@gmail.com', N'123')
INSERT [dbo].[UserViewModels] ([FirstName], [LastName], [NickName], [Gender], [DateOfBirth], [Country], [Email], [Password]) VALUES (N'Carlos', N'Julio', N'CJulio', N'Male', CAST(0x00008D2A00000000 AS DateTime), N'Spain', N'cjulio@gmail.com', N'123')
INSERT [dbo].[UserViewModels] ([FirstName], [LastName], [NickName], [Gender], [DateOfBirth], [Country], [Email], [Password]) VALUES (N'Wilkander', N'Rodriguez', N'WRodriguez', N'Male', CAST(0x00008D2A00000000 AS DateTime), N'Spain', N'wrodriguez@gmail.com', N'123')
GO


UPDATE [dbo].[PersonalizationViewModels] SET [User]=1, [PhotoBackground]='back_1.jpg', [Color]='#000000', [PhotoProfile]='per_1.jpg', [Status]='Today is a good day!!!', [TextColor]='#ffffff' , [ConnectionStatus]='Online' where [PersonalizationId] = 1
UPDATE [dbo].[PersonalizationViewModels] SET [User]=2, [PhotoBackground]='back_2.jpg', [Color]='#6c0000', [PhotoProfile]='per_2.jpg', [Status]='El mejor grupo: Nosotros', [TextColor]='#ffffff' , [ConnectionStatus]='Online' where [PersonalizationId] = 2
UPDATE [dbo].[PersonalizationViewModels] SET [User]=3, [PhotoBackground]='back_3.jpg', [Color]='#000040', [PhotoProfile]='per_3.jpg', [Status]='Cualquier parecido a la realidad es coincidencia', [TextColor]='#ffffff' , [ConnectionStatus]='Busy' where [PersonalizationId] = 3
UPDATE [dbo].[PersonalizationViewModels] SET [User]=4, [PhotoBackground]='back_4.jpg', [Color]='#f0f000', [PhotoProfile]='per_4.jpg', [Status]='Deprende todo lo que no te deje avanzar', [TextColor]='#000000' , [ConnectionStatus]='Online' where [PersonalizationId] = 4
UPDATE [dbo].[PersonalizationViewModels] SET [User]=5, [PhotoBackground]='back_5.jpg', [Color]='#4f009d', [PhotoProfile]='per_5.jpg', [Status]='HTML me comio con yuca.', [TextColor]='#ffffff' , [ConnectionStatus]='Offline' where [PersonalizationId] = 5
UPDATE [dbo].[PersonalizationViewModels] SET [User]=6, [PhotoBackground]='Comple_default_header.png', [Color]='#7fd5f5', [PhotoProfile]='per_6.jpg', [Status]='Hola mundo', [TextColor]='#000000' , [ConnectionStatus]='Busy' where [PersonalizationId] = 6
UPDATE [dbo].[PersonalizationViewModels] SET [User]=7, [PhotoBackground]='Comple_default_header.png', [Color]='#7fd5f5', [PhotoProfile]='per_7.jpg', [Status]='Estoy aqui y que?', [TextColor]='#000000' , [ConnectionStatus]='Online' where [PersonalizationId] = 7
GO

