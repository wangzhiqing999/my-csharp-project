"use strict";


var myAreaInfo = {

    // 调试模式.
    debugMode : true,

    // 获取顶级的区域.
    getRootArea: function (callbackFunc, item) {
        if (myAreaInfo.debugMode) {
            console.log("getRootArea start!");
        }
        
        $.post(
            "/AreaInfo/RootArea",
            { "id": 0 },
        function (data) {
            if (myAreaInfo.debugMode) {
                console.log("getRootArea success!", data);
            }
            callbackFunc(data, item);
            if (myAreaInfo.debugMode) {
                console.log("getRootArea finish!");
            }
        });
    },


    // 查询子区域.
    getSubArea: function (code, callbackFunc, item) {
        if (myAreaInfo.debugMode) {
            console.log("getSubArea start!", code);
        }
        $.post(
            "/AreaInfo/SubArea",
            { "id": code },
        function (data) {
            if (myAreaInfo.debugMode) {
                console.log("getSubArea success!", data);
            }
            callbackFunc(data, item);
            if (myAreaInfo.debugMode) {
                console.log("getSubArea finish!");
            }
        });
    },


    // 设置选择的数据.
    setSelectData: function (dataList, selectItem) {
        // 先删除已有的数据.
        selectItem.children().remove();
        // 再设置新的数据.
        for (var i = 0, len = dataList.length; i < len; i++) {
            selectItem.append('<option value="' + dataList[i].areaCode + '">' + dataList[i].areaName + '</option>');
        }
    },



    // 初始化区域下拉列表.
    initAreaSelect: function (rootItem, subItem) {

        // 初始化顶级区域.
        myAreaInfo.getRootArea(myAreaInfo.setSelectData, rootItem);


        // 顶级区域发生变化时，更新子区域.
        rootItem.change(function () {
            // 选择的 Value.
            var vSelectCode = $(this).val();
            // 查询子区域.
            myAreaInfo.getSubArea(vSelectCode, myAreaInfo.setSelectData, subItem);
        });
    }




}