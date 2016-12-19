
function tracker_krs(kid){var get_krs_cookie=function(name){var prefix=name+"=";var cookieStartIndex=document.cookie.indexOf(prefix);if(cookieStartIndex==-1)return null;var cookieEndIndex=document.cookie.indexOf(";",cookieStartIndex+prefix.length);if(cookieEndIndex==-1)cookieEndIndex=document.cookie.length;return unescape(document.cookie.substring(cookieStartIndex+prefix.length,cookieEndIndex));}
var set_krs_cookie=function(name,value,expires,path,domain,secure){var curCookie=name+"="+escape(value)+
((expires)?"; expires="+expires.toGMTString():"")+
((path)?"; path="+path:"")+
((domain)?"; domain="+domain:"")+
((secure)?"; secure":"");document.cookie=curCookie;}
var dr=escape(document.referrer);var wl=escape(window.location.href);var rw=screen.width;var rh=screen.height;var href='http://www.krs-ix.ru/counter/info/'+kid;var base='http://log.krs-ix.ru/krs.php';var u='';if(window.passport){u=passport.get_user_info();if(u)u=u.uid;else u='';}
var uid=get_krs_cookie("KRSCAT");if(uid===null){var dt=new Date();dt.setTime(dt.getTime()+90*24*60*60*1000);uid=Math.round(Math.random()*999999999);set_krs_cookie("KRSCAT",uid,dt,'');uid=get_krs_cookie("KRSCAT");if(uid===null)uid='1';}
document.write("<a href='"+href+"' target='_blank'><img src='"+base+"?id="+kid+"&s="+uid+"&dr="+dr+"&wl="+wl+"&rw="+rw+"&rh="+rh+"&u="+u+"' border=0 width=88 height=31 alt='KRS-IX Counter'><\/a>");}