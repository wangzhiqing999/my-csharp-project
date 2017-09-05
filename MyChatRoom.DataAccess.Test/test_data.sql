INSERT INTO [dbo].[mcr_house](
	[house_id],[house_page_code],[media_type],
	[login_mode],[house_name],[house_desc],
	[house_logo],[house_password],[house_master_video_address],
	[house_second_video_address],[msg_auto_pass],[msg_keyword_check]
) VALUES (
	'TEST', NULL, 1,
	1,	'测试', '测试使用',
    null, null, null,
    null, 'ACTIVE', null
);


INSERT INTO [dbo].[mcr_user_level](
	[user_level_code],[user_level_name],
	[user_level_css],[user_level_icon],
	[display_index],[msg_auto_pass],[msg_keyword_check]
) VALUES (
	'U01',	'游客',
	null, null,
	1, null, null
);


SET IDENTITY_INSERT [dbo].[mcr_user] ON
go


INSERT INTO [dbo].[mcr_user](
	user_id,
	[user_level_code],[user_name],[user_nick_name],
	[user_photo],[user_password],[is_admin],
	[is_gag],[msg_auto_pass],[msg_keyword_check]
) VALUES (
	1,
	'U01', '游客', '游客',
	NULL, NULL, 0,
	0, NULL, NULL
);

SET IDENTITY_INSERT [dbo].[mcr_user] OFF
go


