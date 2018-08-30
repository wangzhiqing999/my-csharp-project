INSERT INTO mw_word(
	word_value
)
SELECT 'QQ'		UNION ALL
SELECT '微信'	UNION ALL
SELECT '电话'	UNION ALL
SELECT '\d{6}'
;


/*

注意：
现阶段，匹配/替换的处理逻辑
js 客户端是使用 正则表达式的处理机制.
C# 服务器端是使用 完全匹配的处理机制.

目前， \d{6}  这样的玩法， 只在 js 客户端生效， 服务端是无视的。

*/