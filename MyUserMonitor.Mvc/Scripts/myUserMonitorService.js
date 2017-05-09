"use strict";

var myUserMonitorService = {
    // 记录的URL地址.
    recordUrl: "/Api/Enter",
    // 分组.
    id: "TEST",
    // 用户名.
    name: "user001",
    // 间隔.
    interval: 5,

    // 提交.
    enterRecord: function () {
        console.log("enterRecord Start!", this.id, this.name);
        $.ajax(
            {
                url: myUserMonitorService.recordUrl,
                data: "id=" + myUserMonitorService.id + "&name=" + myUserMonitorService.name,
                complete: function (XHR, TS) {
                    myUserMonitorService.enterRecordFinish(XHR, TS);
                }
            }
        );
    },

    // 提交完成.
    enterRecordFinish: function (XHR, TS) {
        console.log("enterRecord Finish!", XHR, TS);
        setTimeout("myUserMonitorService.enterRecord()", this.interval * 1000);
    },

    // 外部调用.
    start: function (pid, pname, pinterval) {
        this.id = pid;
        this.name = pname;
        this.interval = pinterval;
        this.enterRecord();
    }

}