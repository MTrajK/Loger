
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Email], [Username], [Password], [AccountPhotoURL], [CreatedDate]) VALUES (1, N'example1@gmail.com', N'first_user', N'px??i?v&?mc??;DA?G.??q', N'/Uploads/UserPhotos/636108719434676567_1.png', CAST(N'2016-09-30T22:25:34.273' AS DateTime))
INSERT [dbo].[User] ([ID], [Email], [Username], [Password], [AccountPhotoURL], [CreatedDate]) VALUES (2, N'example2@hotmail.com', N'second_user', N'px??i?v&?mc??;DA?G.??q', N'/Uploads/UserPhotos/636108719915112572_2.png', CAST(N'2016-09-30T22:26:55.830' AS DateTime))
INSERT [dbo].[User] ([ID], [Email], [Username], [Password], [AccountPhotoURL], [CreatedDate]) VALUES (3, N'example3@yahoo.com', N'third_user', N'px??i?v&?mc??;DA?G.??q', N'/Uploads/UserPhotos/636108720292907607_3.png', CAST(N'2016-09-30T22:27:38.723' AS DateTime))
INSERT [dbo].[User] ([ID], [Email], [Username], [Password], [AccountPhotoURL], [CreatedDate]) VALUES (4, N'example4@gmail.com', N'fourth_user', N'px??i?v&?mc??;DA?G.??q', N'/Uploads/UserPhotos/636108720700149622_4.png', CAST(N'2016-09-30T22:28:13.627' AS DateTime))
INSERT [dbo].[User] ([ID], [Email], [Username], [Password], [AccountPhotoURL], [CreatedDate]) VALUES (5, N'example5@hotmail.com', N'fifth_user', N'px??i?v&?mc??;DA?G.??q', N'/Uploads/UserPhotos/636108721028333625_5.png', CAST(N'2016-09-30T22:28:40.057' AS DateTime))
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[Photo] ON 

INSERT [dbo].[Photo] ([ID], [URL], [Title], [Description], [CreatedDate], [UserID]) VALUES (1, N'/Uploads/Logos/636108723233429740_1.jpg', N'First Logo', N'White Octopus on green background.', CAST(N'2016-09-30T22:45:23.353' AS DateTime), 1)
INSERT [dbo].[Photo] ([ID], [URL], [Title], [Description], [CreatedDate], [UserID]) VALUES (2, N'/Uploads/Logos/636108723516674905_1.jpg', N'Second Logo', N'Blue-Red Circle.', CAST(N'2016-09-30T22:45:51.677' AS DateTime), 1)
INSERT [dbo].[Photo] ([ID], [URL], [Title], [Description], [CreatedDate], [UserID]) VALUES (3, N'/Uploads/Logos/636108723904803192_1.jpg', N'Same As Second Logo', N'All Black Circle.', CAST(N'2016-09-30T22:46:30.490' AS DateTime), 1)
INSERT [dbo].[Photo] ([ID], [URL], [Title], [Description], [CreatedDate], [UserID]) VALUES (4, N'/Uploads/Logos/636108725611318535_2.jpg', N'HTML 5', N'HTML5 Logo', CAST(N'2016-09-30T22:49:21.137' AS DateTime), 2)
INSERT [dbo].[Photo] ([ID], [URL], [Title], [Description], [CreatedDate], [UserID]) VALUES (5, N'/Uploads/Logos/636108725858669424_2.jpg', N'.NET', N'Microsoft .NET Logo', CAST(N'2016-09-30T22:49:45.870' AS DateTime), 2)
INSERT [dbo].[Photo] ([ID], [URL], [Title], [Description], [CreatedDate], [UserID]) VALUES (6, N'/Uploads/Logos/636108726150885162_2.png', N'C++', N'Fancy C++ Logo', CAST(N'2016-09-30T22:50:15.093' AS DateTime), 2)
INSERT [dbo].[Photo] ([ID], [URL], [Title], [Description], [CreatedDate], [UserID]) VALUES (7, N'/Uploads/Logos/636108726649662931_2.png', N'C', N'Some Logo for C programming language.', CAST(N'2016-09-30T22:51:04.970' AS DateTime), 2)
INSERT [dbo].[Photo] ([ID], [URL], [Title], [Description], [CreatedDate], [UserID]) VALUES (8, N'/Uploads/Logos/636108726896377484_2.png', N'IDK', N'Some interesting logo.', CAST(N'2016-09-30T22:51:29.640' AS DateTime), 2)
INSERT [dbo].[Photo] ([ID], [URL], [Title], [Description], [CreatedDate], [UserID]) VALUES (9, N'/Uploads/Logos/636108728238477501_3.png', N'Panda', N'White-Black Panda Logo.', CAST(N'2016-09-30T22:53:43.850' AS DateTime), 3)
INSERT [dbo].[Photo] ([ID], [URL], [Title], [Description], [CreatedDate], [UserID]) VALUES (10, N'/Uploads/Logos/636108728415009435_3.png', N'Fox', N'Fox Logo.', CAST(N'2016-09-30T22:54:01.503' AS DateTime), 3)
INSERT [dbo].[Photo] ([ID], [URL], [Title], [Description], [CreatedDate], [UserID]) VALUES (11, N'/Uploads/Logos/636108729428180376_4.jpg', N'R', N'R Letter Logo.', CAST(N'2016-09-30T22:55:42.823' AS DateTime), 4)
INSERT [dbo].[Photo] ([ID], [URL], [Title], [Description], [CreatedDate], [UserID]) VALUES (12, N'/Uploads/Logos/636108729603334378_4.jpg', N'A', N'Letter A Logo.', CAST(N'2016-09-30T22:56:00.347' AS DateTime), 4)
INSERT [dbo].[Photo] ([ID], [URL], [Title], [Description], [CreatedDate], [UserID]) VALUES (13, N'/Uploads/Logos/636108730952878207_5.png', N'Burger King', N'Official Burger King Logo.', CAST(N'2016-09-30T22:58:15.290' AS DateTime), 5)
INSERT [dbo].[Photo] ([ID], [URL], [Title], [Description], [CreatedDate], [UserID]) VALUES (14, N'/Uploads/Logos/636108731423349129_5.png', N'Starbucks', N'Official Starbucks Green Logo.', CAST(N'2016-09-30T22:59:02.337' AS DateTime), 5)
SET IDENTITY_INSERT [dbo].[Photo] OFF
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([ID], [Content], [CreatedDate], [UserID], [PhotoID]) VALUES (1, N'Niceeee', CAST(N'2016-09-30T23:00:51.663' AS DateTime), 5, 1)
INSERT [dbo].[Comment] ([ID], [Content], [CreatedDate], [UserID], [PhotoID]) VALUES (2, N'Interesting', CAST(N'2016-09-30T23:01:03.763' AS DateTime), 5, 2)
INSERT [dbo].[Comment] ([ID], [Content], [CreatedDate], [UserID], [PhotoID]) VALUES (3, N'Beautifull', CAST(N'2016-09-30T23:01:19.010' AS DateTime), 5, 11)
INSERT [dbo].[Comment] ([ID], [Content], [CreatedDate], [UserID], [PhotoID]) VALUES (4, N'I aggree', CAST(N'2016-09-30T23:03:00.853' AS DateTime), 4, 1)
INSERT [dbo].[Comment] ([ID], [Content], [CreatedDate], [UserID], [PhotoID]) VALUES (5, N'Yeesss', CAST(N'2016-09-30T23:03:25.273' AS DateTime), 4, 13)
INSERT [dbo].[Comment] ([ID], [Content], [CreatedDate], [UserID], [PhotoID]) VALUES (6, N'Nothing special', CAST(N'2016-09-30T23:04:19.430' AS DateTime), 3, 1)
INSERT [dbo].[Comment] ([ID], [Content], [CreatedDate], [UserID], [PhotoID]) VALUES (7, N'Woooooow', CAST(N'2016-09-30T23:04:48.743' AS DateTime), 3, 10)
INSERT [dbo].[Comment] ([ID], [Content], [CreatedDate], [UserID], [PhotoID]) VALUES (8, N'That i''m looking for', CAST(N'2016-09-30T23:05:41.970' AS DateTime), 2, 1)
INSERT [dbo].[Comment] ([ID], [Content], [CreatedDate], [UserID], [PhotoID]) VALUES (9, N'Rrrrrrrrrr', CAST(N'2016-09-30T23:06:46.473' AS DateTime), 1, 11)
INSERT [dbo].[Comment] ([ID], [Content], [CreatedDate], [UserID], [PhotoID]) VALUES (10, N'Thank youu for support!!!', CAST(N'2016-09-30T23:07:14.770' AS DateTime), 1, 1)
INSERT [dbo].[Comment] ([ID], [Content], [CreatedDate], [UserID], [PhotoID]) VALUES (11, N'Kekekek', CAST(N'2016-09-30T23:07:43.977' AS DateTime), 1, 6)
SET IDENTITY_INSERT [dbo].[Comment] OFF
SET IDENTITY_INSERT [dbo].[Like] ON 

INSERT [dbo].[Like] ([ID], [CreatedDate], [UserID], [PhotoID]) VALUES (1, CAST(N'2016-09-30T23:00:29.113' AS DateTime), 5, 2)
INSERT [dbo].[Like] ([ID], [CreatedDate], [UserID], [PhotoID]) VALUES (2, CAST(N'2016-09-30T23:00:31.040' AS DateTime), 5, 1)
INSERT [dbo].[Like] ([ID], [CreatedDate], [UserID], [PhotoID]) VALUES (3, CAST(N'2016-09-30T23:00:37.310' AS DateTime), 5, 8)
INSERT [dbo].[Like] ([ID], [CreatedDate], [UserID], [PhotoID]) VALUES (4, CAST(N'2016-09-30T23:00:39.077' AS DateTime), 5, 11)
INSERT [dbo].[Like] ([ID], [CreatedDate], [UserID], [PhotoID]) VALUES (5, CAST(N'2016-09-30T23:02:40.660' AS DateTime), 4, 13)
INSERT [dbo].[Like] ([ID], [CreatedDate], [UserID], [PhotoID]) VALUES (6, CAST(N'2016-09-30T23:02:42.567' AS DateTime), 4, 8)
INSERT [dbo].[Like] ([ID], [CreatedDate], [UserID], [PhotoID]) VALUES (7, CAST(N'2016-09-30T23:03:11.767' AS DateTime), 4, 1)
INSERT [dbo].[Like] ([ID], [CreatedDate], [UserID], [PhotoID]) VALUES (8, CAST(N'2016-09-30T23:04:29.073' AS DateTime), 3, 8)
INSERT [dbo].[Like] ([ID], [CreatedDate], [UserID], [PhotoID]) VALUES (9, CAST(N'2016-09-30T23:04:33.717' AS DateTime), 3, 14)
INSERT [dbo].[Like] ([ID], [CreatedDate], [UserID], [PhotoID]) VALUES (10, CAST(N'2016-09-30T23:04:37.567' AS DateTime), 3, 11)
INSERT [dbo].[Like] ([ID], [CreatedDate], [UserID], [PhotoID]) VALUES (11, CAST(N'2016-09-30T23:04:41.763' AS DateTime), 3, 10)
INSERT [dbo].[Like] ([ID], [CreatedDate], [UserID], [PhotoID]) VALUES (12, CAST(N'2016-09-30T23:05:25.650' AS DateTime), 2, 8)
INSERT [dbo].[Like] ([ID], [CreatedDate], [UserID], [PhotoID]) VALUES (13, CAST(N'2016-09-30T23:05:29.330' AS DateTime), 2, 1)
INSERT [dbo].[Like] ([ID], [CreatedDate], [UserID], [PhotoID]) VALUES (14, CAST(N'2016-09-30T23:06:48.617' AS DateTime), 1, 11)
INSERT [dbo].[Like] ([ID], [CreatedDate], [UserID], [PhotoID]) VALUES (15, CAST(N'2016-09-30T23:06:55.823' AS DateTime), 1, 8)
INSERT [dbo].[Like] ([ID], [CreatedDate], [UserID], [PhotoID]) VALUES (16, CAST(N'2016-09-30T23:07:31.553' AS DateTime), 1, 5)
INSERT [dbo].[Like] ([ID], [CreatedDate], [UserID], [PhotoID]) VALUES (17, CAST(N'2016-09-30T23:07:35.050' AS DateTime), 1, 7)
INSERT [dbo].[Like] ([ID], [CreatedDate], [UserID], [PhotoID]) VALUES (18, CAST(N'2016-09-30T23:08:02.617' AS DateTime), 1, 10)
SET IDENTITY_INSERT [dbo].[Like] OFF
SET IDENTITY_INSERT [dbo].[Follow] ON 

INSERT [dbo].[Follow] ([ID], [CreatedDate], [UserFollowingID], [UserFollowedID]) VALUES (1, CAST(N'2016-09-30T22:59:40.913' AS DateTime), 5, 4)
INSERT [dbo].[Follow] ([ID], [CreatedDate], [UserFollowingID], [UserFollowedID]) VALUES (2, CAST(N'2016-09-30T22:59:49.047' AS DateTime), 5, 3)
INSERT [dbo].[Follow] ([ID], [CreatedDate], [UserFollowingID], [UserFollowedID]) VALUES (3, CAST(N'2016-09-30T22:59:55.957' AS DateTime), 5, 2)
INSERT [dbo].[Follow] ([ID], [CreatedDate], [UserFollowingID], [UserFollowedID]) VALUES (4, CAST(N'2016-09-30T23:00:05.017' AS DateTime), 5, 1)
INSERT [dbo].[Follow] ([ID], [CreatedDate], [UserFollowingID], [UserFollowedID]) VALUES (5, CAST(N'2016-09-30T23:02:28.920' AS DateTime), 4, 2)
INSERT [dbo].[Follow] ([ID], [CreatedDate], [UserFollowingID], [UserFollowedID]) VALUES (6, CAST(N'2016-09-30T23:02:34.863' AS DateTime), 4, 5)
INSERT [dbo].[Follow] ([ID], [CreatedDate], [UserFollowingID], [UserFollowedID]) VALUES (7, CAST(N'2016-09-30T23:04:03.067' AS DateTime), 3, 2)
INSERT [dbo].[Follow] ([ID], [CreatedDate], [UserFollowingID], [UserFollowedID]) VALUES (8, CAST(N'2016-09-30T23:06:38.027' AS DateTime), 1, 4)
INSERT [dbo].[Follow] ([ID], [CreatedDate], [UserFollowingID], [UserFollowedID]) VALUES (9, CAST(N'2016-09-30T23:07:28.483' AS DateTime), 1, 2)
SET IDENTITY_INSERT [dbo].[Follow] OFF
