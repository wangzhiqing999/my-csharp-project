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
                localKeywords = new Array();
                localKeywordReg = new Array();

                for (var i = 0; i < data.length; i++) {

                    localKeywords.push(data[i]);

                    var reg = new RegExp(data[i], "g");
                    localKeywordReg.push(reg);
                }

                localKeywordCount = localKeywords.length;
            });
    },


    // 本机判断，是否有关键字.
    localHasKeyword: function (text) {
        for (var i = 0; i < localKeywordCount; i++) {
            if (text.indexOf(localKeywords[i]) >= 0) {
                return true;
            }
        }
        return false;
    },
    // 本机替换关键字.
    localReplace: function (text) {
        var result = text;
        for (var i = 0; i < localKeywordCount; i++) {
            if (result.indexOf(localKeywords[i]) >= 0) {
                result = result.replace(localKeywordReg[i], '*');
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