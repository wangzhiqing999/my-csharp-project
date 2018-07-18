
-- 商品主表
INSERT INTO my_commodity_master (
	commodity_master_code,	commodity_master_name
) 
SELECT 'TEST',  '测试定期出行活动'		UNION ALL
SELECT 'TEST2', '测试定期会议活动'		UNION ALL
SELECT 'TEST3', '测试单次的活动'
;



-- 商品明细模板.
INSERT INTO my_commodity_detail_template(
	commodity_master_code,	commodity_detail_exp_data
)
SELECT 'TEST','{"SeatNumber":"101"}'	UNION ALL
SELECT 'TEST','{"SeatNumber":"102"}'	UNION ALL
SELECT 'TEST','{"SeatNumber":"103"}'	UNION ALL
SELECT 'TEST','{"SeatNumber":"104"}'	UNION ALL
SELECT 'TEST','{"SeatNumber":"201"}'	UNION ALL
SELECT 'TEST','{"SeatNumber":"202"}'	UNION ALL
SELECT 'TEST','{"SeatNumber":"203"}'	UNION ALL
SELECT 'TEST','{"SeatNumber":"204"}'
;