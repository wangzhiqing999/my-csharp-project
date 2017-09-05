var chat;

$(function () {
    chat = $.connection.messageService;


    // 显示错误信息.
    chat.client.showErrorMessage = function (vMessage) {
        alert(vMessage);
    };


    // 显示新发送来的消息.
    chat.client.showNewMessage = function (vMessage) {

        console.log("showNewMessage message = ", vMessage);

        var vLine = "<li id='Li_Message_" + vMessage.MessageID + "' >";

        vLine = vLine + "<h3>";
        vLine = vLine + "<span>" + vMessage.DisplayMessageSenderNickName + "</span>";
        vLine = vLine + "<span>" + vMessage.CreateTime + "</span>";
        vLine = vLine + "</h3>";


        if (vMessage.ImageFlag) {
            vLine = vLine + "<p id='Message_" + vMessage.MessageID + "'><a class='a-img' href='/Upload/Message/" + vMessage.MessageContent + "'  style='display:inline;height:auto;line-height:initial;' ><img src='/Upload/Message/" + vMessage.MessageContent + "' style='height:initial; width:initial; max-width:300px;'>←查看大图</a></p>";
        } else {
            vLine = vLine + "<p id='Message_" + vMessage.MessageID + "'>" + vMessage.MessageContent + "</p>";
        }

        vLine = vLine + "</li>"

        $("#ulMessage").append(vLine);

    }


    // 移除消息.
    chat.client.removeMessage = function (MessageID) {
        var vMsgID = "#Li_Message_" + MessageID;
        var vItem = $(vMsgID);
        if (vItem != null && vItem != undefined) {
            vItem.remove();
        }
    }


    // 更新当前在线用户数.
    chat.client.updateUserCount = function (userCount) {
        $("#myOnlineUserCount").html(userCount);
    }



});



