REM 建仓.
MyMiniTradingSystem.Cmd.exe open -u 000000 -c 510060 -q 2200
MyMiniTradingSystem.Cmd.exe open -u 000000 -c 600642 -q 600


REM  新浪数据导入 (当日 Only ).
MyMiniTradingSystem.Cmd.exe sinaimport -c sh510060
MyMiniTradingSystem.Cmd.exe sinaimport -c sh600642


REM 汇总.
MyMiniTradingSystem.Cmd.exe summary -u 000000 -d 当日 -c all

REM 平仓
MyMiniTradingSystem.Cmd.exe close -u 000000 -c 510060 -q 2200
MyMiniTradingSystem.Cmd.exe close -u 000000 -c 600642 -q 600

