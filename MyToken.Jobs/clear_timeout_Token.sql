
-- ɾ������ TOKEN.
DELETE
	[mt_token]
WHERE
	[Expired_Time] < GETDATE()
GO