"use strict";

var myMenuService = {


    // 查询跟节点菜单.
    getRootMenu: function (callbackFunc) {
        console.log("getRootMenu start!");
        $.post(
            "/Menu/GetRootMenu",
            { "id": 0 },
        function (data) {
            console.log("getRootMenu success!", data);
            callbackFunc(data);
            console.log("getRootMenu finish!");
        });
    },

    // 查询子节点菜单.
    getSubMenu: function (code, callbackFunc) {
        console.log("getSubMenu start!", code);
        $.post(
            "/Menu/GetSubMenu",
            { "id": code },
        function (data) {
            console.log("getSubMenu success!", data);
            callbackFunc(code, data);
            console.log("getSubMenu finish!");
        });
    },



    // 菜单移动.
    moveMenuTo: function (code, pCode, prevCode, callbackFunc) {
        console.log("moveMenuTo start!", code, pCode, prevCode);
        $.post(
            "/Menu/MoveMenuTo",
            {
                "id": code,
                "pid": pCode,
                "previd": prevCode
            },
        function (data) {
            console.log("moveMenuTo success!", data);
            callbackFunc(data);
        });
    },


    // 编辑菜单.
    updateMenu: function (code, pCode, index, text, desc, exp, callbackFunc) {
        console.log("updateMenu start!", code, pCode, index, text, desc, exp);
        $.post(
            "/Menu/UpdateMenu",
            {
                "id": code,
                "pid": pCode,
                "index" : index,
                "text": text,
                "desc": desc,
                "exp": exp
            },
        function (data) {
            console.log("updateMenu success!", data);
            callbackFunc(data);
        });
    },


    // 新增菜单.
    insertMenu: function (code, pCode, index, text, desc, exp, callbackFunc) {
        console.log("InsertMenu start!", code, pCode, index, text, desc, exp);
        $.post(
            "/Menu/InsertMenu",
            {
                "id": code,
                "pid": pCode,
                "index" : index,
                "text": text,
                "desc": desc,
                "exp": exp
            },
        function (data) {
            console.log("InsertMenu success!", data);
            callbackFunc(data);
        });
    },


    // 删除菜单.
    deleteMenu: function (code, callbackFunc) {
        console.log("deleteMenu start!", code);
        $.post(
            "/Menu/DeleteMenu",
            {
                "id": code
            },
        function (data) {
            console.log("deleteMenu success!", data);
            callbackFunc(data);
        });
    }

}