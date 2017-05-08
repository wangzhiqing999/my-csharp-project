"use strict";

var myUserMonitorManager = {



    userSummary: function (callbackFunc) {

        console.log("userSummary start!")

        $.post(
            "/Api/UserSummary",
            { "id": 0 },
        function (data) {
            console.log("userSummary success!", data)

            callbackFunc(data);

            console.log("userSummary finish!")
        });

    },



    userList: function (id, callbackFunc) {

        console.log("userList start!")

        $.post(
            "/Api/UserList",
            { "id": id },
        function (data) {
            console.log("userList success!", data)

            callbackFunc(data);

            console.log("userList finish!")
        });

    }


}