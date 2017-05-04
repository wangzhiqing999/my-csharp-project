"use strict";


var myKeywordService = {

    // 关键字.
    localKeywords : [],
    // 关键字总数.
    localKeywordCount : 0,
    // 本机的关键字正则表达式.
    localKeywordReg : [],

    // 本机加载关键字.
    localAddKeywords : function() {
        $.post(
            '/Keyword/Index',
            {
                "id": 0
            },
            function (data) {
                myKeywordService.localKeywords = new Array();
                myKeywordService.localKeywordReg = new Array();

                for (var i = 0; i < data.length; i++) {

                    myKeywordService.localKeywords.push(data[i]);

                    var reg = new RegExp(data[i], "g");
                    myKeywordService.localKeywordReg.push(reg);
                }

                myKeywordService.localKeywordCount = myKeywordService.localKeywords.length;
            });
    },


    // 本机判断，是否有关键字.
    localHasKeyword: function (text) {
        for (var i = 0; i < this.localKeywordCount; i++) {
            if (text.indexOf(this.localKeywords[i]) >= 0) {
                return true;
            }
        }
        return false;
    },
    // 本机替换关键字.
    localReplace: function (text) {
        var result = text;
        for (var i = 0; i < this.localKeywordCount; i++) {
            if (result.indexOf(this.localKeywords[i]) >= 0) {
                result = result.replace(this.localKeywordReg[i], '*');
            }
        }
        return result;
    },




    // 远程判断，是否有关键字.
    remoteHasKeyword: function (text, callbackFunc) {
        $.post(
            '/Keyword/HasKeyword',
            {
                "text": text
            },
            function (data) {
                callbackFunc(data);
            });
    },
    // 远程替换关键字.
    remoteReplace: function (text, callbackFunc) {
        $.post(
            '/Keyword/Replace',
            {
                "text": text
            },
            function (data) {
                callbackFunc(data);
            });
    }
}