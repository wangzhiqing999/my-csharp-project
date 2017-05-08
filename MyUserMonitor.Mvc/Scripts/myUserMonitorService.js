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
        $.post(
            this.recordUrl,
            { "id": this.id, "name": this.name },
        function (data) {
            myUserMonitorService.enterRecordFinish(data);
        });
    },

    // 提交完成.
    enterRecordFinish: function (data) {
        console.log("enterRecord Finish!", data);
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