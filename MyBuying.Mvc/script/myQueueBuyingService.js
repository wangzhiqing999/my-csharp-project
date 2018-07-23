"use strict"


var myQueueBuyingService = {

    // 是否显示运行日志.
    isShowRunningLog: true,

    // 商品主表代码
    commodityMasterCode: "",

    // 批次.
    batchCode: "",

    // 用户ID.
    userID: "",


    // 获取可购买的数据
    getBuyableDetail: function (callbackFunc) {
        if (this.isShowRunningLog) {
            console.log("getBuyableDetail Start!", this.commodityMasterCode, this.batchCode, this.userID);
        }
        var _this = this;

        $.ajax({
            url: "/QueueBuying/GetBuyableDetail",
            type: 'POST',
            data: {
                id: _this.commodityMasterCode,
                batch: _this.batchCode,
                userID: _this.userID
            },
            cache: false,
            success: function (data) {
                if (_this.isShowRunningLog) {
                    console.log("getBuyableDetail Result:", _this.commodityMasterCode, _this.batchCode, _this.userID, data);
                }
                callbackFunc(data);
            }
        }).fail(function (xhr, textStatus, err) {
            if (_this.isShowRunningLog) {
                console.log(xhr);
                console.log(textStatus);
                console.log(err);
            }
            alert('Error: ' + err);
        });
    },



    isInQueue: function (callbackFunc) {

        if (this.isShowRunningLog) {
            console.log("isInQueue Start!", this.userID);
        }
        var _this = this;

        $.ajax({
            url: "/QueueBuying/IsInQueue",
            type: 'POST',
            data: {
                userID: _this.userID
            },
            cache: false,
            success: function (data) {
                if (_this.isShowRunningLog) {
                    console.log("isInQueue Result:", _this.userID, data);
                }
                callbackFunc(data);
            }
        }).fail(function (xhr, textStatus, err) {
            if (_this.isShowRunningLog) {
                console.log(xhr);
                console.log(textStatus);
                console.log(err);
            }
            alert('Error: ' + err);
        });
    },



    getServiceResult: function (callbackFunc) {

        if (this.isShowRunningLog) {
            console.log("getServiceResult Start!", this.userID);
        }
        var _this = this;

        $.ajax({
            url: "/QueueBuying/GetServiceResult",
            type: 'POST',
            data: {
                userID: _this.userID
            },
            cache: false,
            success: function (data) {
                if (_this.isShowRunningLog) {
                    console.log("getServiceResult Result:", _this.userID, data);
                }
                callbackFunc(data);
            }
        }).fail(function (xhr, textStatus, err) {
            if (_this.isShowRunningLog) {
                console.log(xhr);
                console.log(textStatus);
                console.log(err);
            }
            alert('Error: ' + err);
        });
    }


}