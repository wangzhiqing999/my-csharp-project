"use strict"

var myBuyingService = {

    // 是否显示运行日志.
    isShowRunningLog: true,

    // 商品主表代码
    commodityMasterCode: "",

    // 批次.
    batchCode : "",

    // 用户ID.
    userID : "",


    // 获取可购买的数据
    getBuyableDetail: function (callbackFunc) {
        if (this.isShowRunningLog) {
            console.log("getBuyableDetail Start!", this.commodityMasterCode, this.batchCode, this.userID);
        }
        var _this = this;

        $.ajax({
            url: "/Buying/GetBuyableDetail",
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


    // 创建订单 (购买操作)
    createOrder: function (id, callbackFunc) {
        if (this.isShowRunningLog) {
            console.log("createOrder Start!", id, this.userID);
        }
        var _this = this;

        $.ajax({
            url: "/Buying/CreateOrder",
            type: 'POST',
            data: {
                id: id,
                userID: _this.userID
            },
            cache: false,
            success: function (data) {
                if (_this.isShowRunningLog) {
                    console.log("createOrder Result:", id, _this.userID, data);
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



    // 完成支付 (购买操作)
    orderPayed: function (id, callbackFunc) {
        if (this.isShowRunningLog) {
            console.log("orderPayed Start!", id);
        }
        var _this = this;

        $.ajax({
            url: "/Buying/OrderPayed",
            type: 'POST',
            data: { id: id },
            cache: false,
            success: function (data) {
                if (_this.isShowRunningLog) {
                    console.log("orderPayed Result:", id, data);
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



    // 商品代码使用.
    codeUsed: function (userCode, callbackFunc) {
        if (this.isShowRunningLog) {
            console.log("codeUsed Start!", this.commodityMasterCode, this.batchCode, userCode);
        }
        var _this = this;

        $.ajax({
            url: "/Buying/CodeUsed",
            type: 'POST',
            data: {
                id: _this.commodityMasterCode,
                batch: _this.batchCode,
                userCode: userCode
            },
            cache: false,
            success: function (data) {
                if (_this.isShowRunningLog) {
                    console.log("codeUsed Result:", _this.commodityMasterCode, _this.batchCode, userCode, data);
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



};