"use strict";

var myLoginService = {

    // 是否显示运行日志.
    isShowRunningLog: true,


    // 获取用于手机登录的二维码数据.
    getLoginCode : function (callbackFunc) {
        if (this.isShowRunningLog) {
            console.log("getLoginCode Start!");
        }
        var _this = this;
        $.ajax({
            url: "/Token/CodeLogin",
            type: 'POST',
            success: function (data) {
                if (_this.isShowRunningLog) {
                    console.log("getLoginCode Result:", data);
                }
                callbackFunc(data);
            }
        }).fail(function (xhr, textStatus, err) {
            alert('Error: ' + err);
        });
    },


    // 检测手机 App 是否扫码了.
    isScan: function (callbackFunc) {
        if (this.isShowRunningLog) {
            console.log("isScan Start!");
        }
        var _this = this;
        $.ajax({
            url: "/Token/IsScan",
            type: 'POST',
            success: function (data) {
                if (_this.isShowRunningLog) {
                    console.log("isScan Result:", data);
                }
                callbackFunc(data);
            }
        }).fail(function (xhr, textStatus, err) {
            alert('Error: ' + err);
        });
    },


    // 检测手机 App 是否确认登录了.
    isLogin: function (callbackFunc) {
        if (this.isShowRunningLog) {
            console.log("isLogin Start!");
        }
        var _this = this;
        $.ajax({
            url: "/Token/IsLogin",
            type: 'POST',
            success: function (data) {
                if (_this.isShowRunningLog) {
                    console.log("isLogin Result:", data);
                }
                callbackFunc(data);
            }
        }).fail(function (xhr, textStatus, err) {
            alert('Error: ' + err);
        });
    }


}