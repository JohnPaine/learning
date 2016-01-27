/**
 * Created by shtefan on 13.01.2016.
 */

// ; is for noobies who forget placing ;
;(function () {
    var user = {
        name: "Vasya"
    };

    _.defaults(user, {
        name:"Not assigned",
        employer: "Zavod"
    });

    alert(user.name);
    alert(user.employer);
    alert(_.size(user));

}());