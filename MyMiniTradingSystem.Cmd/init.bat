REM ����.
MyMiniTradingSystem.Cmd.exe open -u 000000 -c 510060 -q 2200
MyMiniTradingSystem.Cmd.exe open -u 000000 -c 600642 -q 600


REM  �������ݵ��� (���� Only ).
MyMiniTradingSystem.Cmd.exe sinaimport -c sh510060
MyMiniTradingSystem.Cmd.exe sinaimport -c sh600642


REM ����.
MyMiniTradingSystem.Cmd.exe summary -u 000000 -d ���� -c all

REM ƽ��
MyMiniTradingSystem.Cmd.exe close -u 000000 -c 510060 -q 2200
MyMiniTradingSystem.Cmd.exe close -u 000000 -c 600642 -q 600

