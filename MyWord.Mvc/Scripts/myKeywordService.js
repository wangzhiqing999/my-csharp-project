"use strict";


var myKeywordService = {

    // 是否显示运行日志.
    isShowRunningLog: true,

    // 关键字总数.
    localKeywordCount: 0,

    // 关键字正则表达式.(检查时使用)
    localKeywords : [],
    
    // 本机的关键字正则表达式.（替换时使用）
    localKeywordReg : [],

    // 本机加载关键字.
    localAddKeywords: function () {
        var _this = this;
        $.post(
            '/Keyword/Index',
            {
                "id": 0
            },
            function (data) {
                if (_this.isShowRunningLog) {
                    console.log("/Keyword/Index Result!", data);
                }

                myKeywordService.localKeywords = new Array();
                myKeywordService.localKeywordReg = new Array();

                for (var i = 0; i < data.length; i++) {
                    // 检索用.
                    var regString = '.?' + data[i] + '.?';
                    var reg = new RegExp(regString, "g");
                    myKeywordService.localKeywords.push(reg);

                    // 替换用.
                    myKeywordService.localKeywordReg.push(new RegExp(data[i], "g"));
                }

                myKeywordService.localKeywordCount = myKeywordService.localKeywords.length;
            });
    },


    // 本机判断，是否有关键字.
    localHasKeyword: function (text) {

        if (this.isShowRunningLog) {
            console.log("localHasKeyword Start.", text);
        }

        for (var i = 0; i < this.localKeywordCount; i++) {

            if (this.isShowRunningLog) {
                console.log("Do test ", this.localKeywords[i]);
            }

            if (this.localKeywords[i].test(text)) {
                if (this.isShowRunningLog) {
                    console.log("test Match!", this.localKeywords[i]);
                }
                return true;
            }
        }
        return false;
    },


    // 本机替换关键字.
    localReplace: function (text) {

        if (this.isShowRunningLog) {
            console.log("localReplace Start.", text);
        }

        var result = text;
        for (var i = 0; i < this.localKeywordCount; i++) {

            if (this.isShowRunningLog) {
                console.log("try Replace!", this.localKeywordReg[i], result);
            }

            result = result.replace(this.localKeywordReg[i], '*');
                
            if (this.isShowRunningLog) {
                console.log("After Replace!", result);
            }
        }
        return result;
    },




    // 远程判断，是否有关键字.
    remoteHasKeyword: function (text, callbackFunc) {
        var _this = this;
        if (this.isShowRunningLog) {
            console.log("remoteHasKeyword Start.", text);
        }

        $.post(
            '/Keyword/HasKeyword',
            {
                "text": text
            },
            function (data) {
                if (_this.isShowRunningLog) {
                    console.log("/Keyword/HasKeyword Result!", data);
                }

                callbackFunc(data);
            });
    },


    // 远程替换关键字.
    remoteReplace: function (text, callbackFunc) {
        var _this = this;
        if (this.isShowRunningLog) {
            console.log("remoteReplace Start.", text);
        }

        $.post(
            '/Keyword/Replace',
            {
                "text": text
            },
            function (data) {
                if (_this.isShowRunningLog) {
                    console.log("/Keyword/Replace Result!", data);
                }

                callbackFunc(data);
            });
    }
}