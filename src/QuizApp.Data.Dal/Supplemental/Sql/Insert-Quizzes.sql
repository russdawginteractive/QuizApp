Use [QuizDatabase]
Go

SET IDENTITY_INSERT [dbo].[Quiz] ON 

GO
INSERT [dbo].[Quiz]  ([Id], [Title], [Description], [PathToQuizReference], [EventId], [Active], [Created], [Modified]) VALUES (1, N'Child Restraint Manufacturing & Materials', N'CEU Test for Certification', N'https://www.youtube.com/watch?v=zbyFRaIJTh4', N'6151', 0, GETDATE(), GETDATE())
GO
INSERT [dbo].[Quiz]  ([Id], [Title], [Description], [PathToQuizReference], [EventId], [Active], [Created], [Modified]) VALUES (4, N'Evenflo Product Update – Summer 2015', N'Featured Products: Evenflo Embrace infant car seat with SensorSafe Technology, Evenflo LiteMax 35 infant car seat, Evenflo Transitions/Evolve combination seats, Evenflo RigthFit booster seat, Evenflo Momentum convertible seat', N'https://www.youtube.com/watch?v=IKm2KvIGfLg', N'6475', 1, GETDATE(), GETDATE())
GO
INSERT [dbo].[Quiz]  ([Id], [Title], [Description], [PathToQuizReference], [EventId], [Active], [Created], [Modified]) VALUES (5, N'Goodbaby International Product Update – Summer 2016', N'Featured Products: Evenflo SafeMax All-in-One and Combination seats, Evenflo LiteMax infant seat, Evenflo SensorSafe Technology, GB Asana 35 DLX, Urbini Sonti, CYBEX Cloud Q', N'https://www.youtube.com/watch?v=Xf0kRkBCuy4', N'6478', 1, GETDATE(), GETDATE())
GO
INSERT [dbo].[Quiz]  ([Id], [Title], [Description], [PathToQuizReference], [EventId], [Active], [Created], [Modified]) VALUES (6, N'Goodbaby International Product Update – Spring 2017', N'Featured Products: Evenflo Spectrum booster seat, Evenflo Sonus convertible seat, Evenflo Sonus 65 convertible seat, Evenflo Stratos convertible seat, CYBEX Sirona M convertible seat, GB Idan infant seat', N'https://www.youtube.com/watch?v=nGJwmrcsG-E', N'6476', 1, GETDATE(), GETDATE())
GO
INSERT [dbo].[Quiz]  ([Id], [Title], [Description], [PathToQuizReference], [EventId], [Active], [Created], [Modified]) VALUES (7, N'Evenflo – Institutional Product Update', N'Featured Products: Full Evenflo institutional car seat line', N'https://youtu.be/ttjkC-tqKZ4', N'6477', 1, GETDATE(), GETDATE())
GO
INSERT [dbo].[Quiz]  ([Id], [Title], [Description], [PathToQuizReference], [EventId], [Active], [Created], [Modified]) VALUES (8, N'Goodbaby International Product Update – Spring 2018', N'Featured Products: Evenflo Spectrum booster seat, Evenflo LiteMax infant seat updates, Evenflo Maestro Sport combination seat, Evenflo Red Tether initiative, Evenflo car seat accessories, CYBEX Sirona M with SensorSafe Technology convertible seat, preview CYBEX Aton M infant seat, Urbini Presti convertible seat, Urbini Asenti all-in-one seat', N'https://www.youtube.com/watch?v=fS-X8iCRA-s&feature=youtu.be', N'6423', 1, GETDATE(), GETDATE())
GO
SET IDENTITY_INSERT [dbo].[Quiz] OFF
GO
