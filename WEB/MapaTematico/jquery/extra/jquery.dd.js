// MSDropDown - jquery.dd.js
// author: Marghoob Suleman - Search me on google
// Date: 12th Aug, 2009
// Version: 2.36 {date: 18 Dec, 2010}
// Revision: 31
// web: www.giftlelo.com | www.marghoobsuleman.com
/*
// msDropDown is free jQuery Plugin: you can redistribute it and/or modify
// it under the terms of the either the MIT License or the Gnu General Public License (GPL) Version 2
*/
//;eval(function(p,a,c,k,e,r){e=function(c){return(c<a?'':e(parseInt(c/a)))+((c=c%a)>35?String.fromCharCode(c+29):c.toString(36))};if(!''.replace(/^/,String)){while(c--)r[e(c)]=k[c]||e(c);k=[function(e){return r[e]}];e=function(){return'\\w+'};c=1};while(c--)if(k[c])p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c]);return p}(';(5($){3 1J="";3 34=5(p,q){3 r=p;3 s=1b;3 q=$.35({1g:3S,2g:7,3a:23,1K:11,1L:3T,3b:\'1Y\',1M:15,3c:\'3U\',2A:\'\',1k:\'\'},q);1b.1U=2h 3d();3 t="";3 u={};u.2B=11;u.2i=15;u.2j=1m;3 v=15;3 w={2C:\'3V\',1N:\'3W\',1O:\'3X\',1P:\'3Y\',1f:\'3Z\',2D:\'41\',2E:\'42\',43:\'44\',2k:\'45\',3e:\'46\'};3 x={1Y:q.3b,2F:\'2F\',2G:\'2G\',2H:\'2H\',1q:\'1q\',1j:.30,2I:\'2I\',2l:\'2l\',2m:\'2m\'};3 y={3f:"2n,2J,2K,1Q,2o,2p,1r,1B,2q,1R,47,1Z,2L",48:"1C,1s,1j,49"};1b.1D=2h 3d();3 z=$(r).12("19");4(3g(z)=="1a"||z.1c<=0){z="4a"+$.1S.3h++;$(r).12("19",z)};3 A=$(r).12("1k");q.1k+=(A==1a)?"":A;3 B=$(r).3i();v=($(r).12("1C")>1||$(r).12("1s")==11)?11:15;4(v){q.2g=$(r).12("1C")};3 C={};3 D=5(a){18 z+w[a]};3 E=5(a){3 b=a;3 c=$(b).12("1k");18 c};3 F=5(a){3 b=$("#"+z+" 2r:8");4(b.1c>1){1t(3 i=0;i<b.1c;i++){4(a==b[i].1h){18 11}}}1d 4(b.1c==1){4(b[0].1h==a){18 11}};18 15};3 G=5(a,b,c,d){3 e="";3 f=(d=="2M")?D("2E"):D("2D");3 g=(d=="2M")?f+"2N"+(b)+"2N"+(c):f+"2N"+(b);3 h="";3 i="";4(q.1M!=15){i=\' \'+q.1M+\' \'+a.3j}1d{h=$(a).12("1V");h=(h.1c==0)?"":\'<3k 3l="\'+h+\'" 3m="3n" /> \'};3 j=$(a).1o();3 k=$(a).4b();3 l=($(a).12("1j")==11)?"1j":"21";C[g]={1E:h+j,22:k,1o:j,1h:a.1h,19:g};3 m=E(a);4(F(a.1h)==11){e+=\'<a 3o="3p:3q(0);" 1p="8 \'+l+i+\'"\'}1d{e+=\'<a  3o="3p:3q(0);" 1p="\'+l+i+\'"\'};4(m!==15&&m!==1a){e+=" 1k=\'"+m+"\'"};e+=\' 19="\'+g+\'">\';e+=h+\'<1u 1p="\'+x.1q+\'">\'+j+\'</1u></a>\';18 e};3 H=5(){3 f=B;4(f.1c==0)18"";3 g="";3 h=D("2D");3 i=D("2E");f.2O(5(c){3 d=f[c];4(d.4c=="4d"){g+="<1v 1p=\'4e\'>";g+="<1u 1k=\'3r-4f:4g;3r-1k:4h; 4i:4j;\'>"+$(d).12("4k")+"</1u>";3 e=$(d).3i();e.2O(5(a){3 b=e[a];g+=G(b,c,a,"2M")});g+="</1v>"}1d{g+=G(d,c,"","")}});18 g};3 I=5(){3 a=D("1N");3 b=D("1f");3 c=q.1k;1W="";1W+=\'<1v 19="\'+b+\'" 1p="\'+x.2H+\'"\';4(!v){1W+=(c!="")?\' 1k="\'+c+\'"\':\'\'}1d{1W+=(c!="")?\' 1k="2s-1w:4l 4m #4n;1x:2t;1y:2P;\'+c+\'"\':\'\'};1W+=\'>\';18 1W};3 J=5(){3 a=D("1O");3 b=D("2k");3 c=D("1P");3 d=D("3e");3 e="";3 f="";4(6.9(z).1F.1c>0){e=$("#"+z+" 2r:8").1o();f=$("#"+z+" 2r:8").12("1V")};f=(f.1c==0||f==1a||q.1K==15||q.1M!=15)?"":\'<3k 3l="\'+f+\'" 3m="3n" /> \';3 g=\'<1v 19="\'+a+\'" 1p="\'+x.2F+\'"\';g+=\'>\';g+=\'<1u 19="\'+b+\'" 1p="\'+x.2G+\'"></1u><1u 1p="\'+x.1q+\'" 19="\'+c+\'">\'+f+\'<1u 1p="\'+x.1q+\'">\'+e+\'</1u></1u></1v>\';18 g};3 K=5(){3 c=D("1f");$("#"+c+" a.21").1I("1Q");$("#"+c+" a.21").1e("1Q",5(a){a.24();N(1b);4(!v){$("#"+c).1I("1B");P(15);3 b=(q.1K==15)?$(1b).1o():$(1b).1E();T(b);s.25()};X()})};3 L=5(){3 d=15;3 e=D("1N");3 f=D("1O");3 g=D("1P");3 h=D("1f");3 i=D("2k");3 j=$("#"+z).2Q();j=j+2;3 k=q.1k;4($("#"+e).1c>0){$("#"+e).2u();d=11};3 l=\'<1v 19="\'+e+\'" 1p="\'+x.1Y+\'"\';l+=(k!="")?\' 1k="\'+k+\'"\':\'\';l+=\'>\';l+=J();l+=I();l+=H();l+="</1v>";l+="</1v>";4(d==11){3 m=D("2C");$("#"+m).2R(l)}1d{$("#"+z).2R(l)};4(v){3 f=D("1O");$("#"+f).2v()};$("#"+e).14("2Q",j+"1T");$("#"+h).14("2Q",(j-2)+"1T");4(B.1c>q.2g){3 n=26($("#"+h+" a:3s").14("28-3t"))+26($("#"+h+" a:3s").14("28-1w"));3 o=((q.3a)*q.2g)-n;$("#"+h).14("1g",o+"1T")}1d 4(v){3 o=$("#"+z).1g();$("#"+h).14("1g",o+"1T")};4(d==15){S();O(z)};4($("#"+z).12("1j")==11){$("#"+e).14("2w",x.1j)};R();$("#"+f).1e("1B",5(a){2S(1)});$("#"+f).1e("1R",5(a){2S(0)});K();$("#"+h+" a.1j").14("2w",x.1j);4(v){$("#"+h).1e("1B",5(c){4(!u.2i){u.2i=11;$(6).1e("1Z",5(a){3 b=a.3u;u.2j=b;4(b==39||b==40){a.24();a.2x();U();X()};4(b==37||b==38){a.24();a.2x();V();X()}})}})};$("#"+h).1e("1R",5(a){P(15);$(6).1I("1Z");u.2i=15;u.2j=1m});$("#"+f).1e("1Q",5(b){P(15);4($("#"+h+":3v").1c==1){$("#"+h).1I("1B")}1d{$("#"+h).1e("1B",5(a){P(11)});s.3w()}});$("#"+f).1e("1R",5(a){P(15)});4(q.1K&&q.1M!=15){W()}};3 M=5(a){1t(3 i 2y C){4(C[i].1h==a){18 C[i]}};18-1};3 N=5(a){3 b=D("1f");4($("#"+b+" a.8").1c==1){t=$("#"+b+" a.8").1o()};4(!v){$("#"+b+" a.8").1G("8")};3 c=$("#"+b+" a.8").12("19");4(c!=1a){3 d=(u.1X==1a||u.1X==1m)?C[c].1h:u.1X};4(a&&!v){$(a).1z("8")};4(v){3 e=u.2j;4($("#"+z).12("1s")==11){4(e==17){u.1X=C[$(a).12("19")].1h;$(a).4o("8")}1d 4(e==16){$("#"+b+" a.8").1G("8");$(a).1z("8");3 f=$(a).12("19");3 g=C[f].1h;1t(3 i=2T.4p(d,g);i<=2T.4q(d,g);i++){$("#"+M(i).19).1z("8")}}1d{$("#"+b+" a.8").1G("8");$(a).1z("8");u.1X=C[$(a).12("19")].1h}}1d{$("#"+b+" a.8").1G("8");$(a).1z("8");u.1X=C[$(a).12("19")].1h}}};3 O=5(a){3 b=a;6.9(b).4r=5(e){$("#"+b).1S(q)}};3 P=5(a){u.2B=a};3 Q=5(){18 u.2B};3 R=5(){3 b=D("1N");3 c=y.3f.4s(",");1t(3 d=0;d<c.1c;d++){3 e=c[d];3 f=Y(e);4(f==11){3x(e){1n"2n":$("#"+b).1e("4t",5(a){6.9(z).2n()});1i;1n"1Q":$("#"+b).1e("1Q",5(a){$("#"+z).1H("1Q")});1i;1n"2o":$("#"+b).1e("2o",5(a){$("#"+z).1H("2o")});1i;1n"2p":$("#"+b).1e("2p",5(a){$("#"+z).1H("2p")});1i;1n"1r":$("#"+b).1e("1r",5(a){$("#"+z).1H("1r")});1i;1n"1B":$("#"+b).1e("1B",5(a){$("#"+z).1H("1B")});1i;1n"2q":$("#"+b).1e("2q",5(a){$("#"+z).1H("2q")});1i;1n"1R":$("#"+b).1e("1R",5(a){$("#"+z).1H("1R")});1i}}}};3 S=5(){3 a=D("2C");$("#"+z).2R("<1v 1p=\'"+x.2I+"\' 1k=\'1g:4u;4v:4w;1y:3y;\' 19=\'"+a+"\'></1v>");$("#"+z).4x($("#"+a))};3 T=5(a){3 b=D("1P");$("#"+b).1E(a)};3 U=5(){3 a=D("1P");3 b=D("1f");3 c=$("#"+b+" a.21");1t(3 d=0;d<c.1c;d++){3 e=c[d];3 f=$(e).12("19");4($(e).3z("8")&&d<c.1c-1){$("#"+b+" a.8").1G("8");$(c[d+1]).1z("8");3 g=$("#"+b+" a.8").12("19");4(!v){3 h=(q.1K==15)?C[g].1o:C[g].1E;T(h)};4(26(($("#"+g).1y().1w+$("#"+g).1g()))>=26($("#"+b).1g())){$("#"+b).29(($("#"+b).29())+$("#"+g).1g()+$("#"+g).1g())};1i}}};3 V=5(){3 a=D("1P");3 b=D("1f");3 c=$("#"+b+" a.21");1t(3 d=0;d<c.1c;d++){3 e=c[d];3 f=$(e).12("19");4($(e).3z("8")&&d!=0){$("#"+b+" a.8").1G("8");$(c[d-1]).1z("8");3 g=$("#"+b+" a.8").12("19");4(!v){3 h=(q.1K==15)?C[g].1o:C[g].1E;T(h)};4(26(($("#"+g).1y().1w+$("#"+g).1g()))<=0){$("#"+b).29(($("#"+b).29()-$("#"+b).1g())-$("#"+g).1g())};1i}}};3 W=5(){4(q.1M!=15){3 a=D("1P");3 b=6.9(z).1F[6.9(z).1l].3j;4(b.1c>0){3 c=D("1f");3 d=$("#"+c+" a."+b).12("19");3 e=$("#"+d).14("2a-4y");3 f=$("#"+d).14("2a-1y");3 g=$("#"+d).14("28-3A");4(e!=1a){$("#"+a).2b("."+x.1q).12(\'1k\',"2a:"+e)};4(f!=1a){$("#"+a).2b("."+x.1q).14(\'2a-1y\',f)};4(g!=1a){$("#"+a).2b("."+x.1q).14(\'28-3A\',g)};$("#"+a).2b("."+x.1q).14(\'2a-3B\',\'4z-3B\');$("#"+a).2b("."+x.1q).14(\'28-3t\',\'4A\')}}};3 X=5(){3 a=D("1f");3 b=$("#"+a+" a.8");4(b.1c==1){3 c=$("#"+a+" a.8").1o();3 d=$("#"+a+" a.8").12("19");4(d!=1a){3 e=C[d].22;6.9(z).1l=C[d].1h};4(q.1K&&q.1M!=15)W()}1d 4(b.1c>1){3 f=$("#"+z+" > 2r:8").4B("8");1t(3 i=0;i<b.1c;i++){3 d=$(b[i]).12("19");3 g=C[d].1h;6.9(z).1F[g].8="8"}};3 h=6.9(z).1l;s.1U["1l"]=h};3 Y=5(a){4($("#"+z).12("4C"+a)!=1a){18 11};3 b=$("#"+z).2U("4D");4(b&&b[a]){18 11};18 15};3 Z=5(){3 b=D("1f");4(Y(\'2K\')==11){3 c=C[$("#"+b+" a.8").12("19")].1o;4($.3C(t)!==$.3C(c)&&t!==""){$("#"+z).1H("2K")}};4(Y(\'1r\')==11){$("#"+z).1H("1r")};4(Y(\'2J\')==11){$(6).1e("1r",5(a){$("#"+z).2n();$("#"+z)[0].2J();X();$(6).1I("1r")})}};3 2S=5(a){3 b=D("2k");4(a==1)$("#"+b).14({3D:\'0 4E%\'});1d $("#"+b).14({3D:\'0 0\'})};3 3E=5(){1t(3 i 2y 6.9(z)){4(3g(6.9(z)[i])!=\'5\'&&6.9(z)[i]!==1a&&6.9(z)[i]!==1m){s.1A(i,6.9(z)[i],11)}}};3 3F=5(a,b){4(M(b)!=-1){6.9(z)[a]=b;3 c=D("1f");$("#"+c+" a.8").1G("8");$("#"+M(b).19).1z("8");3 d=M(6.9(z).1l).1E;T(d)}};3 3G=5(i,a){4(a==\'d\'){1t(3 b 2y C){4(C[b].1h==i){4F C[b];1i}}};3 c=0;1t(3 b 2y C){C[b].1h=c;c++}};3 2V=5(){3 a=D("1f");3 b=D("1N");3 c=$("#"+b).1y();3 d=$("#"+b).1g();3 e=$(3H).1g();3 f=$(3H).29();3 g=$("#"+a).1g();3 h={1L:q.1L,1w:(c.1w+d)+"1T",1x:"2c"};3 i=q.3c;3 j=15;3 k=x.2m;$("#"+a).1G(x.2m);$("#"+a).1G(x.2l);4((e+f)<2T.4G(g+d+c.1w)){3 l=c.1w-g;4((c.1w-g)<0){l=10};h={1L:q.1L,1w:l+"1T",1x:"2c"};i="2W";j=11;k=x.2l};18{2X:j,3I:i,14:h,2s:k}};1b.3w=5(){4((s.2d("1j",11)==11)||(s.2d("1F",11).1c==0))18;3 c=D("1f");4(1J!=""&&c!=1J){$("#"+1J).3J("2Y");$("#"+1J).14({1L:\'0\'})};4($("#"+c).14("1x")=="2c"){t=C[$("#"+c+" a.8").12("19")].1o;$(6).1e("1Z",5(a){3 b=a.3u;4(b==39||b==40){a.24();a.2x();U()};4(b==37||b==38){a.24();a.2x();V()};4(b==27||b==13){s.25();X()};4($("#"+z).12("3K")!=1a){6.9(z).3K()}});$(6).1e("2L",5(a){4($("#"+z).12("3L")!=1a){6.9(z).3L()}});$(6).1e("1r",5(a){4(Q()==15){s.25()}});3 d=2V();$("#"+c).14(d.14);4(d.2X==11){$("#"+c).14({1x:\'2t\'});$("#"+c).1z(d.2s);4(s.1D["2z"]!=1m){2e(s.1D["2z"])(s)}}1d{$("#"+c)[d.3I]("2Y",5(){$("#"+c).1z(d.2s);4(s.1D["2z"]!=1m){2e(s.1D["2z"])(s)}})};4(c!=1J){1J=c}}};1b.25=5(){3 b=D("1f");$(6).1I("1Z");$(6).1I("2L");$(6).1I("1r");3 c=2V();4(c.2X==11){$("#"+b).14("1x","2c")};$("#"+b).3J("2Y",5(a){Z();$("#"+b).14({1L:\'0\'});4(s.1D["3M"]!=1m){2e(s.1D["3M"])(s)}})};1b.1l=5(i){s.1A("1l",i)};1b.1A=5(a,b,c){4(a==1a||b==1a)3N{3O:"1A 4H 4I?"};s.1U[a]=b;4(c!=11){3x(a){1n"1l":3F(a,b);1i;1n"1j":s.1j(b,11);1i;1n"1s":6.9(z)[a]=b;v=($(r).12("1C")>0||$(r).12("1s")==11)?11:15;4(v){3 d=$("#"+z).1g();3 f=D("1f");$("#"+f).14("1g",d+"1T");3 g=D("1O");$("#"+g).2v();3 f=D("1f");$("#"+f).14({1x:\'2t\',1y:\'2P\'});K()};1i;1n"1C":6.9(z)[a]=b;4(b==0){6.9(z).1s=15};v=($(r).12("1C")>0||$(r).12("1s")==11)?11:15;4(b==0){3 g=D("1O");$("#"+g).2W();3 f=D("1f");$("#"+f).14({1x:\'2c\',1y:\'3y\'});3 h="";4(6.9(z).1l>=0){3 i=M(6.9(z).1l);h=i.1E;N($("#"+i.19))};T(h)}1d{3 g=D("1O");$("#"+g).2v();3 f=D("1f");$("#"+f).14({1x:\'2t\',1y:\'2P\'})};1i;4J:4K{6.9(z)[a]=b}4L(e){};1i}}};1b.2d=5(a,b){4(a==1a&&b==1a){18 s.1U};4(a!=1a&&b==1a){18(s.1U[a]!=1a)?s.1U[a]:1m};4(a!=1a&&b!=1a){18 6.9(z)[a]}};1b.3v=5(a){3 b=D("1N");4(a==11){$("#"+b).2W()}1d 4(a==15){$("#"+b).2v()}1d{18 $("#"+b).14("1x")}};1b.4M=5(a,b){3 c=a;3 d=c.1o;3 e=(c.22==1a||c.22==1m)?d:c.22;3 f=(c["1V"]==1a||c["1V"]==1m)?\'\':c["1V"];3 i=(b==1a||b==1m)?6.9(z).1F.1c:b;6.9(z).1F[i]=2h 4N(d,e);4(f!=\'\')6.9(z).1F[i]["1V"]=f;3 g=M(i);4(g!=-1){3 h=G(6.9(z).1F[i],i,"","");$("#"+g.19).1E(h)}1d{3 h=G(6.9(z).1F[i],i,"","");3 j=D("1f");$("#"+j).4O(h);K()}};1b.2u=5(i){6.9(z).2u(i);4((M(i))!=-1){$("#"+M(i).19).2u();3G(i,\'d\')};4(6.9(z).1c==0){T("")}1d{3 a=M(6.9(z).1l).1E;T(a)};s.1A("1l",6.9(z).1l)};1b.1j=5(a,b){6.9(z).1j=a;3 c=D("1N");4(a==11){$("#"+c).14("2w",x.1j);s.25()}1d 4(a==15){$("#"+c).14("2w",1)};4(b!=11){s.1A("1j",a)}};1b.2Z=5(){18(6.9(z).2Z==1a)?1m:6.9(z).2Z};1b.31=5(){4(2f.1c==1){18 6.9(z).31(2f[0])}1d 4(2f.1c==2){18 6.9(z).31(2f[0],2f[1])}1d{3N{3O:"4P 1h 4Q 4R!"}}};1b.3P=5(a){18 6.9(z).3P(a)};1b.1s=5(a){4(a==1a){18 s.2d("1s")}1d{s.1A("1s",a)}};1b.1C=5(a){4(a==1a){18 s.2d("1C")}1d{s.1A("1C",a)}};1b.4S=5(a,b){s.1D[a]=b};1b.4T=5(a){2e(s.1D[a])(s)};3 3Q=5(){s.1A("32",$.1S.32);s.1A("33",$.1S.33)};3 3R=5(){L();3E();3Q();4(q.2A!=\'\'){2e(q.2A)(s)}};3R()};$.1S={32:2.36,33:"4U 4V",3h:20,4W:5(a,b){18 $(a).1S(b).2U("1Y")}};$.4X.35({1S:5(b){18 1b.2O(5(){3 a=2h 34(1b,b);$(1b).2U(\'1Y\',a)})}})})(4Y);',62,309,'|||var|if|function|document||selected|getElementById||||||||||||||||||||||||||||||||||||||||||||||||||||||true|attr||css|false|||return|id|undefined|this|length|else|bind|postChildID|height|index|break|disabled|style|selectedIndex|null|case|text|class|ddTitleText|mouseup|multiple|for|span|div|top|display|position|addClass|set|mouseover|size|onActions|html|options|removeClass|trigger|unbind|bh|showIcon|zIndex|useSprite|postID|postTitleID|postTitleTextID|click|mouseout|msDropDown|px|ddProp|title|sDiv|oldIndex|dd|keydown||enabled|value||preventDefault|close|parseInt||padding|scrollTop|background|find|none|get|eval|arguments|visibleRows|new|keyboardAction|currentKey|postArrowID|borderTop|noBorderTop|focus|dblclick|mousedown|mousemove|option|border|block|remove|hide|opacity|stopPropagation|in|onOpen|onInit|insideWindow|postElementHolder|postAID|postOPTAID|ddTitle|arrow|ddChild|ddOutOfVision|blur|change|keyup|opt|_|each|relative|width|after|bj|Math|data|bn|show|opp|fast|form||item|version|author|bi|extend|||||rowHeight|mainCSS|animStyle|Object|postInputhidden|actions|typeof|counter|children|className|img|src|align|absmiddle|href|javascript|void|font|first|bottom|keyCode|visible|open|switch|absolute|hasClass|left|repeat|trim|backgroundPosition|bk|bl|bm|window|ani|slideUp|onkeydown|onkeyup|onClose|throw|message|namedItem|bo|bp|120|9999|slideDown|_msddHolder|_msdd|_title|_titletext|_child||_msa|_msopta|postInputID|_msinput|_arrow|_inp|keypress|prop|tabindex|msdrpdd|val|nodeName|OPTGROUP|opta|weight|bold|italic|clear|both|label|1px|solid|c3c3c3|toggleClass|min|max|refresh|split|mouseenter|0px|overflow|hidden|appendTo|image|no|2px|removeAttr|on|events|100|delete|floor|to|what|default|try|catch|add|Option|append|An|is|required|addMyEvent|fireEvent|Marghoob|Suleman|create|fn|jQuery'.split('|'),0,{}))
//eval(function(p,a,c,k,e,d){e=function(c){return c.toString(36)};if(!''.replace(/^/,String)){while(c--)d[e(c)]=k[c]||e(c);k=[function(e){return d[e]}];e=function(){return'\\w+'};c=1;};while(c--)if(k[c])p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c]);return p;}(';(8(3){4 2h="";4 4s=8(69,h){4 1l=69;4 s=1j;4 h=3.7v({1c:83,43:7,6h:23,2i:k,2k:81,66:\'4s\',2j:o,6y:\'7p\',7s:\'\',1i:\'\'},h);1j.36=57 67();4 3i="";4 1a={};1a.56=k;1a.41=o;1a.44=1o;4 1f=o;4 6c={5b:\'8g\',35:\'8f\',2n:\'8m\',2q:\'8l\',14:\'8k\',50:\'88\',4y:\'86\',84:\'8b\',48:\'8a\',6u:\'89\'};4 x={4s:h.66,5r:\'5r\',1d:\'1d\',5t:\'5t\',1x:\'1x\',1s:.30,5d:\'5d\',2o:\'2o\',45:\'45\'};4 63={62:"4b,5i,5w,2m,3z,3y,1v,22,49,2r,8d,3p,5h",18:"33,2t,1s,8c"};1j.2g=57 67();4 9=3(1l).j("b");5(6x(9)=="q"||9.u<=0){9="85"+3.6t.87++;3(1l).j("b",9)};4 51=3(1l).j("1i");h.1i+=(51==q)?"":51;4 5o=3(1l).6k();1f=(3(1l).j("33")>1||3(1l).j("2t")==k)?k:o;5(1f){h.43=3(1l).j("33")};4 t={};4 c=8(b){w 9+6c[b]};4 65=8(32){4 2s=32;4 x=3(2s).j("1i");w x};4 6r=8(p){4 1e=3("#"+9+" 32:f");5(1e.u>1){1t(4 i=0;i<1e.u;i++){5(p==1e[i].p){w k}}}12 5(1e.u==1){5(1e[0].p==p){w k}};w o};4 3t=8(1n,15,3v,2u){4 1b="";4 4k=(2u=="3a")?c("4y"):c("50");4 4j=(2u=="3a")?4k+"4u"+(15)+"4u"+(3v):4k+"4u"+(15);4 1d="";4 4m="";5(h.2j!=o){4m=\' \'+h.2j+\' \'+1n.7l}12{1d=3(1n).j("31");1d=(1d.u==0)?"":\'<3o 6o="\'+1d+\'" 64="6d" /> \'};4 r=3(1n).1q();4 3q=3(1n).11();4 4z=(3(1n).j("1s")==k)?"1s":"3d";t[4j]={2d:1d+r,3e:3q,1q:r,p:1n.p,b:4j};4 4o=65(1n);5(6r(1n.p)==k){1b+=\'<a 6p="6v:6s(0);" 1r="f \'+4z+4m+\'"\'}12{1b+=\'<a  6p="6v:6s(0);" 1r="\'+4z+4m+\'"\'};5(4o!==o&&4o!==q){1b+=" 1i=\'"+4o+"\'"};1b+=\' b="\'+4j+\'">\';1b+=1d+\'<1y 1r="\'+x.1x+\'">\'+r+\'</1y></a>\';w 1b};4 61=8(){4 4l=5o;5(4l.u==0)w"";4 1b="";4 7r=c("50");4 4k=c("4y");4l.6l(8(15){4 2s=4l[15];5(2s.80=="7z"){1b+="<20 1r=\'82\'>";1b+="<1y 1i=\'6j-7u:7w;6j-1i:7x; 9h:9g;\'>"+3(2s).j("9a")+"</1y>";4 5x=3(2s).6k();5x.6l(8(3v){4 1n=5x[3v];1b+=3t(1n,15,3v,"3a")});1b+="</20>"}12{1b+=3t(2s,15,"","")}});w 1b};4 6b=8(){4 b=c("35");4 6=c("14");4 2f=h.1i;z="";z+=\'<20 b="\'+6+\'" 1r="\'+x.5t+\'"\';5(!1f){z+=(2f!="")?\' 1i="\'+2f+\'"\':\'\'}12{z+=(2f!="")?\' 1i="4d-1u:9b 9e #9d;21:4n;1z:4t;\'+2f+\'"\':\'\'};z+=\'>\';w z};4 6a=8(){4 1h=c("2n");4 2x=c("48");4 1k=c("2q");4 9c=c("6u");4 r="";4 1d="";5(g.m(9).h.u>0){r=3("#"+9+" 32:f").1q();1d=3("#"+9+" 32:f").j("31")};1d=(1d.u==0||1d==q||h.2i==o||h.2j!=o)?"":\'<3o 6o="\'+1d+\'" 64="6d" /> \';4 z=\'<20 b="\'+1h+\'" 1r="\'+x.5r+\'"\';z+=\'>\';z+=\'<1y b="\'+2x+\'" 1r="\'+x.1d+\'"></1y><1y 1r="\'+x.1x+\'" b="\'+1k+\'">\'+1d+\'<1y 1r="\'+x.1x+\'">\'+r+\'</1y></1y></20>\';w z};4 4q=8(){4 6=c("14");3("#"+6+" a.3d").2e("2m");3("#"+6+" a.3d").y("2m",8(n){n.3l();4w(1j);5(!1f){3("#"+6).2e("22");2v(o);4 r=(h.2i==o)?3(1j).1q():3(1j).2d();2p(r);s.4i()};2w();})};4 9i=8(){4 42=o;4 b=c("35");4 1h=c("2n");4 1k=c("2q");4 6=c("14");4 2x=c("48");4 3x=3("#"+9).5m();3x=3x+2;4 2f=h.1i;5(3("#"+b).u>0){3("#"+b).4r();42=k};4 z=\'<20 b="\'+b+\'" 1r="\'+x.4s+\'"\';z+=(2f!="")?\' 1i="\'+2f+\'"\':\'\';z+=\'>\';z+=6a();z+=6b();z+=61();z+="</20>";z+="</20>";5(42==k){4 6q=c("5b");3("#"+6q).5a(z)}12{3("#"+9).5a(z)};5(1f){4 1h=c("2n");3("#"+1h).4f()};3("#"+b).l("5m",3x+"2l");3("#"+6).l("5m",(3x-2)+"2l");5(5o.u>h.43){4 6f=3m(3("#"+6+" a:6n").l("3h-7i"))+3m(3("#"+6+" a:6n").l("3h-1u"));4 34=((h.6h)*h.43)-6f;3("#"+6).l("1c",34+"2l")}12 5(1f){4 34=3("#"+9).1c();3("#"+6).l("1c",34+"2l")};5(42==o){7m();6i(9)};5(3("#"+9).j("1s")==k){3("#"+b).l("6m",x.1s)};6e();3("#"+1h).y("22",8(n){5g(1)});3("#"+1h).y("2r",8(n){5g(0)});4q();3("#"+6+" a.1s").l("6m",x.1s);5(1f){3("#"+6).y("22",8(n){5(!1a.41){1a.41=k;3(g).y("3p",8(n){4 19=n.19;1a.44=19;5(19==39||19==40){n.3l();n.4p();60();2w()};5(19==37||19==38){n.3l();n.4p();5v();2w()}})}})};3("#"+6).y("2r",8(n){2v(o);3(g).2e("3p");1a.41=o;1a.44=1o});3("#"+1h).y("2m",8(n){2v(o);5(3("#"+6+":76").u==1){3("#"+6).2e("22")}12{3("#"+6).y("22",8(n){2v(k)});s.7d()}});3("#"+1h).y("2r",8(5n){2v(o)});5(h.2i&&h.2j!=o){52()}};4 26=8(p){1t(4 i 47 t){5(t[i].p==p){w t[i]}};w-1};4 4w=8(1p){4 6=c("14");5(3("#"+6+" a.f").u==1){3i=3("#"+6+" a.f").1q();};5(!1f){3("#"+6+" a.f").24("f")};4 v=3("#"+6+" a.f").j("b");5(v!=q){4 28=(1a.28==q||1a.28==1o)?t[v].p:1a.28};5(1p&&!1f){3(1p).1w("f")};5(1f){4 19=1a.44;5(3("#"+9).j("2t")==k){5(19==17){1a.28=t[3(1p).j("b")].p;3(1p).8o("f");}12 5(19==16){3("#"+6+" a.f").24("f");3(1p).1w("f");4 6g=3(1p).j("b");4 4x=t[6g].p;1t(4 i=5k.8s(28,4x);i<=5k.8r(28,4x);i++){3("#"+26(i).b).1w("f")}}12{3("#"+6+" a.f").24("f");3(1p).1w("f");1a.28=t[3(1p).j("b")].p}}12{3("#"+6+" a.f").24("f");3(1p).1w("f");1a.28=t[3(1p).j("b")].p};}};4 6i=8(b){4 5c=b;g.m(5c).95=8(e){3("#"+5c).6t(h)}};4 2v=8(11){1a.56=11};4 7h=8(){w 1a.56};4 6e=8(){4 2a=c("35");4 55=63.62.92(",");1t(4 46=0;46<55.u;46++){4 3n=55[46];4 68=3s(3n);5(68==k){7g(3n){1m"4b":3("#"+2a).y("98",8(n){g.m(9).4b();});1g;1m"2m":3("#"+2a).y("2m",8(n){3("#"+9).29("2m")});1g;1m"3z":3("#"+2a).y("3z",8(n){3("#"+9).29("3z")});1g;1m"3y":3("#"+2a).y("3y",8(n){3("#"+9).29("3y")});1g;1m"1v":3("#"+2a).y("1v",8(n){3("#"+9).29("1v");});1g;1m"22":3("#"+2a).y("22",8(n){3("#"+9).29("22")});1g;1m"49":3("#"+2a).y("49",8(n){3("#"+9).29("49")});1g;1m"2r":3("#"+2a).y("2r",8(n){3("#"+9).29("2r")});1g}}}};4 7m=8(){4 53=c("5b");3("#"+9).5a("<20 1r=\'"+x.5d+"\' 1i=\'1c:91;90:8y;1z:7c;\' b=\'"+53+"\'></20>");3("#"+9).8z(3("#"+53))};4 2p=8(r){4 1k=c("2q");3("#"+1k).2d(r)};4 60=8(){4 1k=c("2q");4 6=c("14");4 25=3("#"+6+" a.3d");1t(4 15=0;15<25.u;15++){4 2z=25[15];4 b=3(2z).j("b");5(3(2z).7n("f")&&15<25.u-1){3("#"+6+" a.f").24("f");3(25[15+1]).1w("f");4 v=3("#"+6+" a.f").j("b");5(!1f){4 r=(h.2i==o)?t[v].1q:t[v].2d;2p(r)};5(3m((3("#"+v).1z().1u+3("#"+v).1c()))>=3m(3("#"+6).1c())){3("#"+6).3k((3("#"+6).3k())+3("#"+v).1c()+3("#"+v).1c())};1g}}};4 5v=8(){4 1k=c("2q");4 6=c("14");4 25=3("#"+6+" a.3d");1t(4 15=0;15<25.u;15++){4 2z=25[15];4 b=3(2z).j("b");5(3(2z).7n("f")&&15!=0){3("#"+6+" a.f").24("f");3(25[15-1]).1w("f");4 v=3("#"+6+" a.f").j("b");5(!1f){4 r=(h.2i==o)?t[v].1q:t[v].2d;2p(r)};5(3m((3("#"+v).1z().1u+3("#"+v).1c()))<=0){3("#"+6).3k((3("#"+6).3k()-3("#"+6).1c())-3("#"+v).1c())};1g}}};4 52=8(){5(h.2j!=o){4 1k=c("2q");4 54=g.m(9).h[g.m(9).1e].7l;5(54.u>0){4 6=c("14");4 b=3("#"+6+" a."+54).j("b");4 59=3("#"+b).l("3b-96");4 3w=3("#"+b).l("3b-1z");4 5e=3("#"+b).l("3h-7k");5(59!=q){3("#"+1k).3j("."+x.1x).j(\'1i\',"3b:"+59)};5(3w!=q){3("#"+1k).3j("."+x.1x).l(\'3b-1z\',3w)};5(5e!=q){3("#"+1k).3j("."+x.1x).l(\'3h-7k\',5e)};3("#"+1k).3j("."+x.1x).l(\'3b-7j\',\'97-7j\');3("#"+1k).3j("."+x.1x).l(\'3h-7i\',\'93\')}}};4 2w=8(){4 6=c("14");4 3r=3("#"+6+" a.f");5(3r.u==1){4 r=3("#"+6+" a.f").1q();4 v=3("#"+6+" a.f").j("b");5(v!=q){4 3q=t[v].3e;g.m(9).1e=t[v].p};5(h.2i&&h.2j!=o)52()}12 5(3r.u>1){4 94=3("#"+9+" > 32:f").8q("f");1t(4 i=0;i<3r.u;i++){4 v=3(3r[i]).j("b");4 p=t[v].p;g.m(9).h[p].f="f"}};4 72=g.m(9).1e;s.36["1e"]=72;};4 3s=8(5z){5(3("#"+9).j("8p"+5z)!=q){w k};4 5s=3("#"+9).8w("8x");5(5s&&5s[5z]){w k};w o};4 7b=8(){4 6=c("14");5(3s(\'5w\')==k){4 73=t[3("#"+6+" a.f").j("b")].1q;5(3.71(3i)!==3.71(73)&&3i!==""){3("#"+9).29("5w")}};5(3s(\'1v\')==k){3("#"+9).29("1v")};5(3s(\'5i\')==k){3(g).y("1v",8(5n){3("#"+9).4b();3("#"+9)[0].5i();2w();3(g).2e("1v")})}};4 5g=8(75){4 2x=c("48");5(75==1)3("#"+2x).l({3w:\'0 8v%\'});12 3("#"+2x).l({3w:\'0 0\'})};4 8t=8(){1t(4 i 47 g.m(9)){5(6x(g.m(9)[i])!=\'8\'&&g.m(9)[i]!==q&&g.m(9)[i]!==1o){s.4c(i,g.m(9)[i],k);}}};4 7e=8(18,11){5(26(11)!=-1){g.m(9)[18]=11;4 6=c("14");3("#"+6+" a.f").24("f");3("#"+26(11).b).1w("f");4 r=26(g.m(9).1e).2d;2p(r)}};4 74=8(i,3n){5(3n==\'d\'){1t(4 3f 47 t){5(t[3f].p==i){8u t[3f];1g}}};4 5p=0;1t(4 3f 47 t){t[3f].p=5p;5p++}};4 5u=8(){4 6=c("14");4 5l=c("35");4 3g=3("#"+5l).1z();4 5q=3("#"+5l).1c();4 70=3(6w).1c();4 6z=3(6w).3k();4 4a=3("#"+6).1c();4 l={2k:h.2k,1u:(3g.1u+5q)+"2l",21:"3c"};4 3u=h.6y;4 2y=o;4 2o=x.45;3("#"+6).24(x.45);3("#"+6).24(x.2o);5((70+6z)<5k.9f(4a+5q+3g.1u)){4 2u=3g.1u-4a;5((3g.1u-4a)<0){2u=10};l={2k:h.2k,1u:2u+"2l",21:"3c"};3u="58";2y=k;2o=x.2o};w{2y:2y,3u:3u,l:l,4d:2o}};1j.7d=8(){5((s.4h("1s",k)==k)||(s.4h("h",k).u==0))w;4 6=c("14");5(2h!=""&&6!=2h){3("#"+2h).79("5j");3("#"+2h).l({2k:\'0\'})};5(3("#"+6).l("21")=="3c"){3i=t[3("#"+6+" a.f").j("b")].1q;3(g).y("3p",8(n){4 19=n.19;5(19==39||19==40){n.3l();n.4p();60()};5(19==37||19==38){n.3l();n.4p();5v()};5(19==27||19==13){s.4i();2w()};5(3("#"+9).j("78")!=q){g.m(9).78()}});3(g).y("5h",8(n){5(3("#"+9).j("77")!=q){g.m(9).77()}});3(g).y("1v",8(5n){5(7h()==o){s.4i()}});4 2c=5u();3("#"+6).l(2c.l);5(2c.2y==k){3("#"+6).l({21:\'4n\'});3("#"+6).1w(2c.4d);5(s.2g["4e"]!=1o){5y(s.2g["4e"])(s)}}12{3("#"+6)[2c.3u]("5j",8(){3("#"+6).1w(2c.4d);5(s.2g["4e"]!=1o){5y(s.2g["4e"])(s)}})};5(6!=2h){2h=6}}};1j.4i=8(){4 6=c("14");3(g).2e("3p");3(g).2e("5h");3(g).2e("1v");4 2c=5u();5(2c.2y==k){3("#"+6).l("21","3c")};3("#"+6).79("5j",8(n){7b();3("#"+6).l({2k:\'0\'});5(s.2g["7a"]!=1o){5y(s.2g["7a"])(s)}})};1j.1e=8(i){s.4c("1e",i)};1j.4c=8(18,11,7f){5(18==q||11==q)99{7y:"4c 7t 7o?"};s.36[18]=11;5(7f!=k){7g(18){1m"1e":7e(18,11);1g;1m"1s":s.1s(11,k);1g;1m"2t":g.m(9)[18]=11;1f=(3(1l).j("33")>0||3(1l).j("2t")==k)?k:o;5(1f){4 34=3("#"+9).1c();4 6=c("14");3("#"+6).l("1c",34+"2l");4 1h=c("2n");3("#"+1h).4f();4 6=c("14");3("#"+6).l({21:\'4n\',1z:\'4t\'});4q()};1g;1m"33":g.m(9)[18]=11;5(11==0){g.m(9).2t=o};1f=(3(1l).j("33")>0||3(1l).j("2t")==k)?k:o;5(11==0){4 1h=c("2n");3("#"+1h).58();4 6=c("14");3("#"+6).l({21:\'3c\',1z:\'7c\'});4 r="";5(g.m(9).1e>=0){4 4v=26(g.m(9).1e);r=4v.2d;4w(3("#"+4v.b))};2p(r)}12{4 1h=c("2n");3("#"+1h).4f();4 6=c("14");3("#"+6).l({21:\'4n\',1z:\'4t\'})};1g;7q:8h{g.m(9)[18]=11}8i(e){};1g}};};1j.4h=8(18,4g){5(18==q&&4g==q){w s.36};5(18!=q&&4g==q){w(s.36[18]!=q)?s.36[18]:1o};5(18!=q&&4g!=q){w g.m(9)[18]}};1j.76=8(11){4 b=c("35");5(11==k){3("#"+b).58()}12 5(11==o){3("#"+b).4f()}12{w 3("#"+b).l("21")}};1j.8e=8(3a,p){4 2b=3a;4 r=2b.1q;4 3q=(2b.3e==q||2b.3e==1o)?r:2b.3e;4 3o=(2b["31"]==q||2b["31"]==1o)?\'\':2b["31"];4 i=(p==q||p==1o)?g.m(9).h.u:p;g.m(9).h[i]=57 8n(r,3q);5(3o!=\'\')g.m(9).h[i]["31"]=3o;4 5f=26(i);5(5f!=-1){4 1b=3t(g.m(9).h[i],i,"","");3("#"+5f.b).2d(1b);}12{4 1b=3t(g.m(9).h[i],i,"","");4 6=c("14");3("#"+6).8j(1b);4q()}};1j.4r=8(i){g.m(9).4r(i);5((26(i))!=-1){3("#"+26(i).b).4r();74(i,\'d\')};5(g.m(9).u==0){2p("")}12{4 r=4h',36,343,'|||jQuery|var|if|childid||function|elementid||id|getPostID|||selected|document|options||attr|true|css|getElementById|event|false|index|undefined|sText|jQuerythis|a_array|length|selectedA|return|styles|bind|sDiv||val|else||postChildID|current|||prop|keyCode|actionSettings|aTag|height|arrow|selectedIndex|ddList|break|titleid|style|this|titletextid|sElement|case|currentOptOption|null|obj|text|class|disabled|for|top|mouseup|addClass|ddTitleText|span|position|div|display|mouseover||removeClass|allAs|getByIndex||oldIndex|trigger|mainid|objOpt|wf|html|unbind|sStyle|onActions|msOldDiv|showIcon|useSprite|zIndex|px|click|postTitleID|borderTop|setTitleText|postTitleTextID|mouseout|currentOption|multiple|tp|setInsideWindow|setValue|arrowid|opp|currentA||title|option|size|iHeight|postID|ddProp||||opt|background|none|enabled|value|key|pos|padding|oldSelectedValue|find|scrollTop|preventDefault|parseInt|action|img|keydown|sValue|allSelected|has_handler|createA|ani|currentopt|backgroundPosition|iWidth|mousedown|dblclick||keyboardAction|changeInsertionPoint|visibleRows|currentKey|noBorderTop|iCount|in|postArrowID|mousemove|cH|focus|set|border|onOpen|hide|forceRefresh|get|close|aid|aidoptfix|childnodes|clsName|block|innerStyle|stopPropagation|applyEventsOnA|remove|dd|relative|_|aObj|manageSelection|currentIndex|postOPTAID|sEnabledClass|postAID|inlineCSS|setTitleImageSprite|sId|sClassName|actions_array|insideWindow|new|show|backgroundImg|after|postElementHolder|objid|ddOutOfVision|paddingLeft|ifA|hightlightArrow|keyup|blur|fast|Math|main|width|evt|allOptions|count|mH|ddTitle|evs|ddChild|shouldOpenOpposite|previous|change|optChild|eval|name|next|createATags|actions|attributes|align|getOptionsProperties|mainCSS|Object|actionFound|element|createTitleDiv|createChildDiv|config|absmiddle|applyEvents|margin|currentSelected|rowHeight|addRefreshMethods|font|children|each|opacity|first|src|href|sid|matchIndex|void|msDropDown|postInputhidden|javascript|window|typeof|animStyle|st|wH|trim|sIndex|currentSelectedValue|addRemoveFromIndex|ison|visible|onkeyup|onkeydown|slideUp|onClose|checkMethodAndApply|absolute|open|setValueByIndex|isLocal|switch|getInsideWindow|bottom|repeat|left|className|setOutOfVision|hasClass|what|slideDown|default|aidfix|onInit|to|weight|extend|bold|italic|message|OPTGROUP|nodeName|9999|opta|120|postInputID|msdrpdd|_msopta|counter|_msa|_inp|_arrow|_msinput|tabindex|keypress|add|_msdd|_msddHolder|try|catch|append|_child|_titletext|_title|Option|toggleClass|on|removeAttr|max|min|setOriginalProperties|delete|100|data|events|hidden|appendTo|overflow|0px|split|2px|alls|refresh|image|no|mouseenter|throw|label|1px|inputhidden|c3c3c3|solid|floor|both|clear|createDropDown'.split('|'),0,{}))


;(function(jQuery) {
   var msOldDiv = ""; 
   var dd = function(element, options)
   {
		var sElement = element;
		var jQuerythis =  this; //parent this
		var options = jQuery.extend({
			height:120,
			visibleRows:7,
			rowHeight:23,
			showIcon:true,
			zIndex:9999,
			mainCSS:'dd',
			useSprite:false,
			animStyle:'slideDown',
			onInit:'',
			style:''
		}, options);
		this.ddProp = new Object();//storing propeties;
		var oldSelectedValue = "";
		var actionSettings ={};
		actionSettings.insideWindow = true;
		actionSettings.keyboardAction = false;
		actionSettings.currentKey = null;
		var ddList = false;
		var config = {postElementHolder:'_msddHolder', postID:'_msdd', postTitleID:'_title',postTitleTextID:'_titletext',postChildID:'_child',postAID:'_msa',postOPTAID:'_msopta',postInputID:'_msinput', postArrowID:'_arrow', postInputhidden:'_inp'};
		var styles = {dd:options.mainCSS, ddTitle:'ddTitle', arrow:'arrow', ddChild:'ddChild', ddTitleText:'ddTitleText', disabled:.30, ddOutOfVision:'ddOutOfVision', borderTop:'borderTop', noBorderTop:'noBorderTop'};
		var attributes = {actions:"focus,blur,change,click,dblclick,mousedown,mouseup,mouseover,mousemove,mouseout,keypress,keydown,keyup", prop:"size,multiple,disabled,tabindex"};
		this.onActions = new Object();
		var elementid = jQuery(sElement).attr("id");
		if(typeof(elementid)=="undefined" || elementid.length<=0) {
			//assign and id;
			elementid = "msdrpdd"+jQuery.msDropDown.counter++;//I guess it makes unique for the page.
			jQuery(sElement).attr("id", elementid);
		};
		var inlineCSS = jQuery(sElement).attr("style");
		options.style += (inlineCSS==undefined) ? "" : inlineCSS;
		var allOptions = jQuery(sElement).children();
		ddList = (jQuery(sElement).attr("size")>1 || jQuery(sElement).attr("multiple")==true) ? true : false;
		if(ddList) {options.visibleRows = jQuery(sElement).attr("size");};
		var a_array = {};//stores id, html & value etc
		
	var getPostID = function (id) {
		return elementid+config[id];
	};
	var getOptionsProperties = function (option) {
		var currentOption = option;
		var styles = jQuery(currentOption).attr("style");
		return styles;
	};
	var matchIndex = function (index) {
		var selectedIndex = jQuery("#"+elementid+" option:selected");
		if(selectedIndex.length>1) {
			for(var i=0;i<selectedIndex.length;i++) {
				if(index == selectedIndex[i].index) {
					return true;
				};
			};
		} else if(selectedIndex.length==1) {
			if(selectedIndex[0].index==index) {
				return true;
			};
		};
		return false;
	};
	var createA = function(currentOptOption, current, currentopt, tp) {
		var aTag = "";
		//var aidfix = getPostID("postAID");
		var aidoptfix = (tp=="opt") ? getPostID("postOPTAID") : getPostID("postAID");		
		var aid = (tp=="opt") ? aidoptfix+"_"+(current)+"_"+(currentopt) : aidoptfix+"_"+(current);
		var arrow = "";
		var clsName = "";
		if(options.useSprite!=false) {
		 clsName = ' '+options.useSprite+' '+currentOptOption.className;
		} else {
		 arrow = jQuery(currentOptOption).attr("title");
		 arrow = (arrow.length==0) ? "" : '<img src="'+arrow+'" align="absmiddle" /> ';																 
		};
		//console.debug("clsName "+clsName);
		var sText = jQuery(currentOptOption).text();
		var sValue = jQuery(currentOptOption).val();
		var sEnabledClass = (jQuery(currentOptOption).attr("disabled")==true) ? "disabled" : "enabled";
		a_array[aid] = {html:arrow + sText, value:sValue, text:sText, index:currentOptOption.index, id:aid};
		var innerStyle = getOptionsProperties(currentOptOption);
		if(matchIndex(currentOptOption.index)==true) {
		 aTag += '<a href="javascript:void(0);" class="selected '+sEnabledClass+clsName+'"';
		} else {
		aTag += '<a  href="javascript:void(0);" class="'+sEnabledClass+clsName+'"';
		};
		if(innerStyle!==false && innerStyle!==undefined) {
		aTag +=  " style='"+innerStyle+"'";
		};
		aTag +=  ' id="'+aid+'">';
		aTag += arrow + '<span class="'+styles.ddTitleText+'">' +sText+'</span></a>';
		return aTag;
	};
	var createATags = function () {
		var childnodes = allOptions;
		if(childnodes.length==0) return "";
		var aTag = "";
		var aidfix = getPostID("postAID");
		var aidoptfix = getPostID("postOPTAID");
		childnodes.each(function(current){
								 var currentOption = childnodes[current];
								 //OPTGROUP
								 if(currentOption.nodeName == "OPTGROUP") {
								  	aTag += "<div class='opta'>";
									 aTag += "<span style='font-weight:bold;font-style:italic; clear:both;'>"+jQuery(currentOption).attr("label")+"</span>";
									 var optChild = jQuery(currentOption).children();
									 optChild.each(function(currentopt){
															var currentOptOption = optChild[currentopt];
															 aTag += createA(currentOptOption, current, currentopt, "opt");
															});
									 aTag += "</div>";
									 
								 } else {
									 aTag += createA(currentOption, current, "", "");
								 };
								 });
		return aTag;
	};
	var createChildDiv = function () {
		var id = getPostID("postID");
		var childid = getPostID("postChildID");
		var sStyle = options.style;
		sDiv = "";
		sDiv += '<div id="'+childid+'" class="'+styles.ddChild+'"';
		if(!ddList) {
			sDiv += (sStyle!="") ? ' style="'+sStyle+'"' : ''; 
		} else {
			sDiv += (sStyle!="") ? ' style="border-top:1px solid #c3c3c3;display:block;position:relative;'+sStyle+'"' : ''; 
		};
		sDiv += '>';		
		return sDiv;
	};

	var createTitleDiv = function () {
		var titleid = getPostID("postTitleID");
		var arrowid = getPostID("postArrowID");
		var titletextid = getPostID("postTitleTextID");
		var inputhidden = getPostID("postInputhidden");
		var sText = "";
		var arrow = "";
		if(document.getElementById(elementid).options.length>0) {
			sText = jQuery("#"+elementid+" option:selected").text();
			arrow = jQuery("#"+elementid+" option:selected").attr("title");
		};
		//console.debug("sObj	 "+sObj.length);
		arrow = (arrow.length==0 || arrow==undefined || options.showIcon==false || options.useSprite!=false) ? "" : '<img src="'+arrow+'" align="absmiddle" /> ';
		var sDiv = '<div id="'+titleid+'" class="'+styles.ddTitle+'"';
		sDiv += '>';
		sDiv += '<span id="'+arrowid+'" class="'+styles.arrow+'"></span><span class="'+styles.ddTitleText+'" id="'+titletextid+'">'+arrow + '<span class="'+styles.ddTitleText+'">'+sText+'</span></span></div>';
		return sDiv;
	};
	var applyEventsOnA = function() {
		var childid = getPostID("postChildID");
		jQuery("#"+childid+ " a.enabled").unbind("click"); //remove old one
			jQuery("#"+childid+ " a.enabled").bind("click", function(event) {
														 event.preventDefault();
														 manageSelection(this);
														 if(!ddList) {
															 jQuery("#"+childid).unbind("mouseover");
															 setInsideWindow(false);															 
															 var sText = (options.showIcon==false) ? jQuery(this).text() : jQuery(this).html();
															 //alert("sText "+sText);
															  setTitleText(sText);
															  //jQuerythis.data("dd").close();
															  jQuerythis.close();
														 };
														 setValue();
														 //actionSettings.oldIndex = a_array[jQuery(jQuerythis).attr("id")].index;
														 });		
	};
	var createDropDown = function () {
		var changeInsertionPoint = false;
		var id = getPostID("postID");
		var titleid = getPostID("postTitleID");
		var titletextid = getPostID("postTitleTextID");
		var childid = getPostID("postChildID");
		var arrowid = getPostID("postArrowID");
		var iWidth = jQuery("#"+elementid).width();
		iWidth = iWidth+2;//it always give -2 width; i dont know why
		var sStyle = options.style;
		if(jQuery("#"+id).length>0) {
			jQuery("#"+id).remove();
			changeInsertionPoint = true;
		};
		var sDiv = '<div id="'+id+'" class="'+styles.dd+'"';
		sDiv += (sStyle!="") ? ' style="'+sStyle+'"' : '';
		sDiv += '>';
		//create title bar
		sDiv += createTitleDiv();
		//create child
		sDiv += createChildDiv();
		sDiv += createATags();
		sDiv += "</div>";
		sDiv += "</div>";
		if(changeInsertionPoint==true) {
			var sid =getPostID("postElementHolder");
			jQuery("#"+sid).after(sDiv);
		} else {
			jQuery("#"+elementid).after(sDiv);
		};
		if(ddList) {
			var titleid = getPostID("postTitleID");	
			jQuery("#"+titleid).hide();
		};
		
		jQuery("#"+id).css("width", iWidth+"px");
		jQuery("#"+childid).css("width", (iWidth-2)+"px");
		if(allOptions.length>options.visibleRows) {
			var margin = parseInt(jQuery("#"+childid+" a:first").css("padding-bottom")) + parseInt(jQuery("#"+childid+" a:first").css("padding-top"));
			var iHeight = ((options.rowHeight)*options.visibleRows) - margin;
			jQuery("#"+childid).css("height", iHeight+"px");
		} else if(ddList) {
			var iHeight = jQuery("#"+elementid).height();
			jQuery("#"+childid).css("height", iHeight+"px");
		};
		//set out of vision
		if(changeInsertionPoint==false) {
			setOutOfVision();
			addRefreshMethods(elementid);
		};
		if(jQuery("#"+elementid).attr("disabled")==true) {
			jQuery("#"+id).css("opacity", styles.disabled);
		};
		applyEvents();
		//add events
		//arrow hightlight
		jQuery("#"+titleid).bind("mouseover", function(event) {
												  hightlightArrow(1);
												  });
		jQuery("#"+titleid).bind("mouseout", function(event) {
												  hightlightArrow(0);
												  });
			//open close events
		applyEventsOnA();
		jQuery("#"+childid+ " a.disabled").css("opacity", styles.disabled);
		//alert("ddList "+ddList)
		if(ddList) {
			jQuery("#"+childid).bind("mouseover", function(event) {if(!actionSettings.keyboardAction) {
																 actionSettings.keyboardAction = true;
																 jQuery(document).bind("keydown", function(event) {
																									var keyCode = event.keyCode;	
																									actionSettings.currentKey = keyCode;
																									if(keyCode==39 || keyCode==40) {
																										//move to next
																										event.preventDefault(); event.stopPropagation();
																										next();
																										setValue();
																									};
																									if(keyCode==37 || keyCode==38) {
																										event.preventDefault(); event.stopPropagation();
																										//move to previous
																										previous();
																										setValue();
																									};
																									  });
																 
																 }});
		};
		jQuery("#"+childid).bind("mouseout", function(event) {setInsideWindow(false);jQuery(document).unbind("keydown");actionSettings.keyboardAction = false;actionSettings.currentKey=null;});
		jQuery("#"+titleid).bind("click", function(event) {
											  setInsideWindow(false);
												if(jQuery("#"+childid+":visible").length==1) {
													jQuery("#"+childid).unbind("mouseover");
												} else {
													jQuery("#"+childid).bind("mouseover", function(event) {setInsideWindow(true);});
													//alert("open "+elementid + jQuerythis);
													//jQuerythis.data("dd").openMe();
													jQuerythis.open();
												};
											  });
		jQuery("#"+titleid).bind("mouseout", function(evt) {
												 setInsideWindow(false);
												 });
		if(options.showIcon && options.useSprite!=false) {
			setTitleImageSprite();
		};
	};
	var getByIndex = function (index) {
		for(var i in a_array) {
			if(a_array[i].index==index) {
				return a_array[i];
			};
		};
		return -1;
	};
	var manageSelection = function (obj) {
		var childid = getPostID("postChildID");
		if(jQuery("#"+childid+ " a.selected").length==1) { //check if there is any selected
			oldSelectedValue = jQuery("#"+childid+ " a.selected").text(); //i should have value here. but sometime value is missing
			//alert("oldSelectedValue "+oldSelectedValue);
		};
		if(!ddList) {
			jQuery("#"+childid+ " a.selected").removeClass("selected");
		}; 
		var selectedA = jQuery("#"+childid + " a.selected").attr("id");
		if(selectedA!=undefined) {
			var oldIndex = (actionSettings.oldIndex==undefined || actionSettings.oldIndex==null) ? a_array[selectedA].index : actionSettings.oldIndex;
		};
		if(obj && !ddList) {
			jQuery(obj).addClass("selected");
		};	
		if(ddList) {
			var keyCode = actionSettings.currentKey;
			if(jQuery("#"+elementid).attr("multiple")==true) {
				if(keyCode == 17) {
					//control
						actionSettings.oldIndex = a_array[jQuery(obj).attr("id")].index;
						jQuery(obj).toggleClass("selected");
					//multiple
				} else if(keyCode==16) {
					jQuery("#"+childid+ " a.selected").removeClass("selected");
					jQuery(obj).addClass("selected");
					//shift
					var currentSelected = jQuery(obj).attr("id");
					var currentIndex = a_array[currentSelected].index;
					for(var i=Math.min(oldIndex, currentIndex);i<=Math.max(oldIndex, currentIndex);i++) {
						jQuery("#"+getByIndex(i).id).addClass("selected");
					};
				} else {
					jQuery("#"+childid+ " a.selected").removeClass("selected");
					jQuery(obj).addClass("selected");
					actionSettings.oldIndex = a_array[jQuery(obj).attr("id")].index;
				};
			} else {
					jQuery("#"+childid+ " a.selected").removeClass("selected");
					jQuery(obj).addClass("selected");
					actionSettings.oldIndex = a_array[jQuery(obj).attr("id")].index;				
			};
			//isSingle
		};		
	};
	var addRefreshMethods = function (id) {
		//deprecated
		var objid = id;
		document.getElementById(objid).refresh = function(e) {
			 jQuery("#"+objid).msDropDown(options);
		};
	};
	var setInsideWindow = function (val) {
		actionSettings.insideWindow = val;
	};
	var getInsideWindow = function () {
		return actionSettings.insideWindow;
	};
	var applyEvents = function () {
		var mainid = getPostID("postID");
		var actions_array = attributes.actions.split(",");
		for(var iCount=0;iCount<actions_array.length;iCount++) {
			var action = actions_array[iCount];
			//var actionFound = jQuery("#"+elementid).attr(action);
			var actionFound = has_handler(action);//jQuery("#"+elementid).attr(action);
			//console.debug(elementid +" action " + action , "actionFound "+actionFound);
			if(actionFound==true) {
				switch(action) {
					case "focus": 
					jQuery("#"+mainid).bind("mouseenter", function(event) {
													   document.getElementById(elementid).focus();
													   //jQuery("#"+elementid).focus();
													   });
					break;
					case "click": 
					jQuery("#"+mainid).bind("click", function(event) {
													   //document.getElementById(elementid).onclick();
													   jQuery("#"+elementid).trigger("click");
													   });
					break;
					case "dblclick": 
					jQuery("#"+mainid).bind("dblclick", function(event) {
													   //document.getElementById(elementid).ondblclick();
													   jQuery("#"+elementid).trigger("dblclick");
													   });
					break;
					case "mousedown": 
					jQuery("#"+mainid).bind("mousedown", function(event) {
													   //document.getElementById(elementid).onmousedown();
													   jQuery("#"+elementid).trigger("mousedown");
													   });
					break;
					case "mouseup": 
					//has in close mthod
					jQuery("#"+mainid).bind("mouseup", function(event) {
													   //document.getElementById(elementid).onmouseup();
													   jQuery("#"+elementid).trigger("mouseup");
													   //setValue();
													   });
					break;
					case "mouseover": 
					jQuery("#"+mainid).bind("mouseover", function(event) {
													   //document.getElementById(elementid).onmouseover();													   
													   jQuery("#"+elementid).trigger("mouseover");
													   });
					break;
					case "mousemove": 
					jQuery("#"+mainid).bind("mousemove", function(event) {
													   //document.getElementById(elementid).onmousemove();
													   jQuery("#"+elementid).trigger("mousemove");
													   });
					break;
					case "mouseout": 
					jQuery("#"+mainid).bind("mouseout", function(event) {
													   //document.getElementById(elementid).onmouseout();
													   jQuery("#"+elementid).trigger("mouseout");
													   });
					break;					
				};
			};
		};
		
	};
	var setOutOfVision = function () {
		var sId = getPostID("postElementHolder");
		jQuery("#"+elementid).after("<div class='"+styles.ddOutOfVision+"' style='height:0px;overflow:hidden;position:absolute;' id='"+sId+"'></div>");
		jQuery("#"+elementid).appendTo(jQuery("#"+sId));
	};
	var setTitleText = function (sText) {
		var titletextid = getPostID("postTitleTextID");
		jQuery("#"+titletextid).html(sText);		
	};
	var next = function () {
		var titletextid = getPostID("postTitleTextID");
		var childid = getPostID("postChildID");
		var allAs = jQuery("#"+childid + " a.enabled");
		for(var current=0;current<allAs.length;current++) {
			var currentA = allAs[current];
			var id = jQuery(currentA).attr("id");
			if(jQuery(currentA).hasClass("selected") && current<allAs.length-1) {
				jQuery("#"+childid + " a.selected").removeClass("selected");
				jQuery(allAs[current+1]).addClass("selected");
				//manageSelection(allAs[current+1]);
				var selectedA = jQuery("#"+childid + " a.selected").attr("id");
				if(!ddList) {
					var sText = (options.showIcon==false) ? a_array[selectedA].text : a_array[selectedA].html;
					setTitleText(sText);
				};
				if(parseInt((jQuery("#"+selectedA).position().top+jQuery("#"+selectedA).height()))>=parseInt(jQuery("#"+childid).height())) {
					jQuery("#"+childid).scrollTop((jQuery("#"+childid).scrollTop())+jQuery("#"+selectedA).height()+jQuery("#"+selectedA).height());
				};
				break;
			};
		};
	};
	var previous = function () {
		var titletextid = getPostID("postTitleTextID");
		var childid = getPostID("postChildID");
		var allAs = jQuery("#"+childid + " a.enabled");
		for(var current=0;current<allAs.length;current++) {
			var currentA = allAs[current];
			var id = jQuery(currentA).attr("id");
			if(jQuery(currentA).hasClass("selected") && current!=0) {
				jQuery("#"+childid + " a.selected").removeClass("selected");
				jQuery(allAs[current-1]).addClass("selected");				
				//manageSelection(allAs[current-1]);
				var selectedA = jQuery("#"+childid + " a.selected").attr("id");
				if(!ddList) {
					var sText = (options.showIcon==false) ? a_array[selectedA].text : a_array[selectedA].html;
					setTitleText(sText);
				};
				if(parseInt((jQuery("#"+selectedA).position().top+jQuery("#"+selectedA).height())) <=0) {
					jQuery("#"+childid).scrollTop((jQuery("#"+childid).scrollTop()-jQuery("#"+childid).height())-jQuery("#"+selectedA).height());
				};
				break;
			};
		};
	};
	var setTitleImageSprite = function() {
		if(options.useSprite!=false) {
			var titletextid = getPostID("postTitleTextID");
			var sClassName = document.getElementById(elementid).options[document.getElementById(elementid).selectedIndex].className;
			if(sClassName.length>0) {
				var childid = getPostID("postChildID");
				var id = jQuery("#"+childid + " a."+sClassName).attr("id");
				var backgroundImg = jQuery("#"+id).css("background-image");
				var backgroundPosition = jQuery("#"+id).css("background-position");
				var paddingLeft = jQuery("#"+id).css("padding-left");
				if(backgroundImg!=undefined) {
					jQuery("#"+titletextid).find("."+styles.ddTitleText).attr('style', "background:"+backgroundImg);
				};
				if(backgroundPosition!=undefined) {
					jQuery("#"+titletextid).find("."+styles.ddTitleText).css('background-position', backgroundPosition);
				};
				if(paddingLeft!=undefined) {
					jQuery("#"+titletextid).find("."+styles.ddTitleText).css('padding-left', paddingLeft);	
				};
				jQuery("#"+titletextid).find("."+styles.ddTitleText).css('background-repeat', 'no-repeat');				
				jQuery("#"+titletextid).find("."+styles.ddTitleText).css('padding-bottom', '2px');
			};
		};		
	};
	var setValue = function () {
		//alert("setValue "+elementid);
		var childid = getPostID("postChildID");
		var allSelected = jQuery("#"+childid + " a.selected");
		if(allSelected.length==1) {
			var sText = jQuery("#"+childid + " a.selected").text();
			var selectedA = jQuery("#"+childid + " a.selected").attr("id");
			if(selectedA!=undefined) {
				var sValue = a_array[selectedA].value;
				document.getElementById(elementid).selectedIndex = a_array[selectedA].index;
			};
			//set image on title if using sprite
			if(options.showIcon && options.useSprite!=false)
				setTitleImageSprite();
		} else if(allSelected.length>1) { 
			var alls = jQuery("#"+elementid +" > option:selected").removeAttr("selected");
			for(var i=0;i<allSelected.length;i++) {
				var selectedA = jQuery(allSelected[i]).attr("id");
				var index = a_array[selectedA].index;
				document.getElementById(elementid).options[index].selected = "selected";
			};
		};
		//alert(document.getElementById(elementid).selectedIndex);
		var sIndex = document.getElementById(elementid).selectedIndex;
		jQuerythis.ddProp["selectedIndex"]= sIndex;
		//alert("selectedIndex "+ jQuerythis.ddProp["selectedIndex"] + " sIndex "+sIndex);
	};
	var has_handler = function (name) {
		// True if a handler has been added in the html.
		if (jQuery("#"+elementid).attr("on" + name) != undefined) {
			return true;
		};
		// True if a handler has been added using jQuery.
		var evs = jQuery("#"+elementid).data("events");
		if (evs && evs[name]) {
			return true;
		};
		return false;
	};
	var checkMethodAndApply = function () {
		var childid = getPostID("postChildID");
		if(has_handler('change')==true) {
			//alert(1);
			var currentSelectedValue = a_array[jQuery("#"+childid +" a.selected").attr("id")].text;
			if(jQuery.trim(oldSelectedValue) !== jQuery.trim(currentSelectedValue) && oldSelectedValue!==""){
				jQuery("#"+elementid).trigger("change");
			};
		};
		if(has_handler('mouseup')==true) {
			jQuery("#"+elementid).trigger("mouseup");
		};
		if(has_handler('blur')==true) { 
			jQuery(document).bind("mouseup", function(evt) {
												   jQuery("#"+elementid).focus();
												   jQuery("#"+elementid)[0].blur();
												   setValue();
												   jQuery(document).unbind("mouseup");
												});
		};
	};
	var hightlightArrow = function(ison) {
		var arrowid = getPostID("postArrowID");
		if(ison==1)
			jQuery("#"+arrowid).css({backgroundPosition:'0 100%'});
		else 
			jQuery("#"+arrowid).css({backgroundPosition:'0 0'});
	};
	var setOriginalProperties = function() {
		//properties = {};
		//alert(jQuerythis.data("dd"));
		for(var i in document.getElementById(elementid)) {
			if(typeof(document.getElementById(elementid)[i])!='function' && document.getElementById(elementid)[i]!==undefined && document.getElementById(elementid)[i]!==null) {
				jQuerythis.set(i, document.getElementById(elementid)[i], true);//true = setting local properties
			};
		};
	};
	var setValueByIndex = function(prop, val) {
			if(getByIndex(val) != -1) {
				document.getElementById(elementid)[prop] = val;
				var childid = getPostID("postChildID");
				jQuery("#"+childid+ " a.selected").removeClass("selected");
				jQuery("#"+getByIndex(val).id).addClass("selected");
				var sText = getByIndex(document.getElementById(elementid).selectedIndex).html;
				setTitleText(sText);				
			};
	};
	var addRemoveFromIndex = function(i, action) {
		if(action=='d') {
			for(var key in a_array) {
				if(a_array[key].index == i) {
					delete a_array[key];
					break;
				};
			};
		};
		//update index
		var count = 0;
		for(var key in a_array) {
			a_array[key].index = count;
			count++;
		};
	};
	var shouldOpenOpposite = function() {
		var childid = getPostID("postChildID");
		var main = getPostID("postID");
		var pos = jQuery("#"+main).position();
		var mH = jQuery("#"+main).height();
		var wH = jQuery(window).height();
		var st = jQuery(window).scrollTop();
		var cH = jQuery("#"+childid).height();
		var css = {zIndex:options.zIndex, top:(pos.top+mH)+"px", display:"none"};
		var ani = options.animStyle;
		var opp = false;
		var borderTop = styles.noBorderTop;
		jQuery("#"+childid).removeClass(styles.noBorderTop);
		jQuery("#"+childid).removeClass(styles.borderTop);
		if( (wH+st) < Math.floor(cH+mH+pos.top) ) {
			var tp = pos.top-cH;
			if((pos.top-cH)<0) {
				tp = 10;
			};
			css = {zIndex:options.zIndex, top:tp+"px", display:"none"};
			ani = "show";
			opp = true;
			borderTop = styles.borderTop;
		};
		return {opp:opp, ani:ani, css:css, border:borderTop};
	};	
	/************* public methods *********************/
	this.open = function() {
		if((jQuerythis.get("disabled", true) == true) || (jQuerythis.get("options", true).length==0)) return;
		var childid = getPostID("postChildID");
		if(msOldDiv!="" && childid!=msOldDiv) { 
			jQuery("#"+msOldDiv).slideUp("fast");
			jQuery("#"+msOldDiv).css({zIndex:'0'});
		};
		if(jQuery("#"+childid).css("display")=="none") {
			oldSelectedValue = a_array[jQuery("#"+childid +" a.selected").attr("id")].text;
			//keyboard action
			jQuery(document).bind("keydown", function(event) {
													var keyCode = event.keyCode;											
													if(keyCode==39 || keyCode==40) {
														//move to next
														event.preventDefault(); event.stopPropagation();
														next();
													};
													if(keyCode==37 || keyCode==38) {
														event.preventDefault(); event.stopPropagation();
														//move to previous
														previous();
													};
													if(keyCode==27 || keyCode==13) {
														//jQuerythis.data("dd").close();
														jQuerythis.close();
														setValue();
													};
													if(jQuery("#"+elementid).attr("onkeydown")!=undefined) {
															document.getElementById(elementid).onkeydown();
														};														
													   });
					
			jQuery(document).bind("keyup", function(event) {
				if(jQuery("#"+elementid).attr("onkeyup")!=undefined) {
				//jQuery("#"+elementid).keyup();
				document.getElementById(elementid).onkeyup();
				};												 
			});
			//end keyboard action
			
			//close onmouseup
			jQuery(document).bind("mouseup", function(evt){
													if(getInsideWindow()==false) {
													//alert("evt.target: "+evt.target);
													 //jQuerythis.data("dd").close();
													 jQuerythis.close();
													};
												 });													  
			
			//check open
			var wf = shouldOpenOpposite();
			jQuery("#"+childid).css(wf.css);
			if(wf.opp==true) {
				jQuery("#"+childid).css({display:'block'});
				jQuery("#"+childid).addClass(wf.border);
				  if(jQuerythis.onActions["onOpen"]!=null) {
					  eval(jQuerythis.onActions["onOpen"])(jQuerythis);
				  };				
			} else {
				jQuery("#"+childid)[wf.ani]("fast", function() {
														  jQuery("#"+childid).addClass(wf.border);
														  if(jQuerythis.onActions["onOpen"]!=null) {
															  eval(jQuerythis.onActions["onOpen"])(jQuerythis);
														  };
														  });
			};
			if(childid != msOldDiv) {
				msOldDiv = childid;
			};
		};
	};
	this.close = function() {
				var childid = getPostID("postChildID");
				jQuery(document).unbind("keydown");
				jQuery(document).unbind("keyup");
				jQuery(document).unbind("mouseup");
				var wf = shouldOpenOpposite();
				if(wf.opp==true) {
					jQuery("#"+childid).css("display", "none");
				};
				jQuery("#"+childid).slideUp("fast", function(event) {
															checkMethodAndApply();
															jQuery("#"+childid).css({zIndex:'0'});
															if(jQuerythis.onActions["onClose"]!=null) {
														  		eval(jQuerythis.onActions["onClose"])(jQuerythis);
													  		};
															});
		
	};
	this.selectedIndex = function(i) {
		jQuerythis.set("selectedIndex", i);
	};
	//update properties
	this.set = function(prop, val, isLocal) {
		//alert("- set " + prop + " : "+val);
		if(prop==undefined || val==undefined) throw {message:"set to what?"}; 
		jQuerythis.ddProp[prop] = val;
		if(isLocal!=true) { 
			switch(prop) {
				case "selectedIndex":
					setValueByIndex(prop, val);
				break;
				case "disabled":
					jQuerythis.disabled(val, true);
				break;
				case "multiple":
					document.getElementById(elementid)[prop] = val;
					ddList = (jQuery(sElement).attr("size")>0 || jQuery(sElement).attr("multiple")==true) ? true : false;	
					if(ddList) {
						//do something
						var iHeight = jQuery("#"+elementid).height();
						var childid = getPostID("postChildID");
						jQuery("#"+childid).css("height", iHeight+"px");					
						//hide titlebar
						var titleid = getPostID("postTitleID");
						jQuery("#"+titleid).hide();
						var childid = getPostID("postChildID");
						jQuery("#"+childid).css({display:'block',position:'relative'});
						applyEventsOnA();
					};
				break;
				case "size":
					document.getElementById(elementid)[prop] = val;
					if(val==0) {
						document.getElementById(elementid).multiple = false;
					};
					ddList = (jQuery(sElement).attr("size")>0 || jQuery(sElement).attr("multiple")==true) ? true : false;	
					if(val==0) {
						//show titlebar
						var titleid = getPostID("postTitleID");
						jQuery("#"+titleid).show();
						var childid = getPostID("postChildID");
						jQuery("#"+childid).css({display:'none',position:'absolute'});
						var sText = "";
						if(document.getElementById(elementid).selectedIndex>=0) {
							var aObj = getByIndex(document.getElementById(elementid).selectedIndex);
							sText = aObj.html;
							manageSelection(jQuery("#"+aObj.id));
						}; 
						setTitleText(sText);
					} else {
						//hide titlebar
						var titleid = getPostID("postTitleID");
						jQuery("#"+titleid).hide();
						var childid = getPostID("postChildID");
						jQuery("#"+childid).css({display:'block',position:'relative'});						
					};
				break;
				default:
				try{
					//check if this is not a readonly properties
					document.getElementById(elementid)[prop] = val;
				} catch(e) {
					//silent
				};				
				break;
			};
		};
		//alert("get " + prop + " : "+jQuerythis.ddProp[prop]);
		//jQuerythis.set("selectedIndex", 0);
	};
	this.get = function(prop, forceRefresh) {
		if(prop==undefined && forceRefresh==undefined) {
			//alert("c1 : " +jQuerythis.ddProp);
		 	return jQuerythis.ddProp;
		};
		if(prop!=undefined && forceRefresh==undefined) {
			//alert("c2 : " +jQuerythis.ddProp[prop]);
			return (jQuerythis.ddProp[prop]!=undefined) ? jQuerythis.ddProp[prop] : null;
		};
		if(prop!=undefined && forceRefresh!=undefined) {
			//alert("c3 : " +document.getElementById(elementid)[prop]);
			return document.getElementById(elementid)[prop];
		};
	};
	this.visible = function(val) {
		var id = getPostID("postID");
		if(val==true) {
			jQuery("#"+id).show();
		} else if(val==false) {
			jQuery("#"+id).hide();
		} else {
			return jQuery("#"+id).css("display");
		};
	};
	this.add = function(opt, index) {
		var objOpt = opt;
		var sText = objOpt.text;
		var sValue = (objOpt.value==undefined || objOpt.value==null) ? sText : objOpt.value;
		var img = (objOpt["title"]==undefined || objOpt["title"]==null) ? '' : objOpt["title"];
		var i = (index==undefined || index==null) ? document.getElementById(elementid).options.length : index;
		document.getElementById(elementid).options[i] = new Option(sText, sValue);
		if(img!='') document.getElementById(elementid).options[i]["title"] = img;
		//check if exist
		var ifA = getByIndex(i);
		if(ifA != -1) {
			//replace
			var aTag = createA(document.getElementById(elementid).options[i], i, "", "");
			jQuery("#"+ifA.id).html(aTag);
			//a_array[key]
		} else {
			var aTag = createA(document.getElementById(elementid).options[i], i, "", "");
			//add
			var childid = getPostID("postChildID");
			jQuery("#"+childid).append(aTag);
			applyEventsOnA();
		};
	};	
	this.remove = function(i) {
		document.getElementById(elementid).remove(i);
		if((getByIndex(i))!= -1) { jQuery("#"+getByIndex(i).id).remove();addRemoveFromIndex(i, 'd');};
		//alert("a" +a);
		if(document.getElementById(elementid).length==0) {
			setTitleText("");
		} else {
			var sText = getByIndex(document.getElementById(elementid).selectedIndex).html;
			setTitleText(sText);
		};
		jQuerythis.set("selectedIndex", document.getElementById(elementid).selectedIndex);
	};
	this.disabled = function(dis, isLocal) {
		document.getElementById(elementid).disabled = dis;
		//alert(document.getElementById(elementid).disabled);
		var id = getPostID("postID");
		if(dis==true) {
			jQuery("#"+id).css("opacity", styles.disabled);
			jQuerythis.close();
		} else if(dis==false) {
			jQuery("#"+id).css("opacity", 1);
		};
		if(isLocal!=true) {
			jQuerythis.set("disabled", dis);
		};
	};
	//return form element
	this.form = function() {
		return (document.getElementById(elementid).form == undefined) ? null : document.getElementById(elementid).form;
	};
	this.item = function() {
		//index, subindex - use arguments.length
		if(arguments.length==1) {
			return document.getElementById(elementid).item(arguments[0]);
		} else if(arguments.length==2) {
			return document.getElementById(elementid).item(arguments[0], arguments[1]);
		} else {
			throw {message:"An index is required!"};
		};
	};
	this.namedItem = function(nm) {
		return document.getElementById(elementid).namedItem(nm);
	};
	this.multiple = function(is) {
		if(is==undefined) {
			return jQuerythis.get("multiple");
		} else {
			jQuerythis.set("multiple", is);
		};
		
	};
	this.size = function(sz) {
		if(sz==undefined) {
			return jQuerythis.get("size");
		} else {
			jQuerythis.set("size", sz);
		};		
	};	
	this.addMyEvent = function(nm, fn) {
		jQuerythis.onActions[nm] = fn;
	};
	this.fireEvent = function(nm) {
		eval(jQuerythis.onActions[nm])(jQuerythis);
	};
	//end 
	var updateCommonVars = function() {
		jQuerythis.set("version", jQuery.msDropDown.version);
		jQuerythis.set("author", jQuery.msDropDown.author);
	};
	var init = function() {
		//create wrapper
		createDropDown();
		//update propties
		//alert("init");
		setOriginalProperties();
		updateCommonVars();
		if(options.onInit!='') {
			eval(options.onInit)(jQuerythis);
		};		
	};
	init();
	};
	//static
	jQuery.msDropDown = {
		version: 2.36,
		author: "Marghoob Suleman",
		counter:20,
		create: function(id, opt) {
			return jQuery(id).msDropDown(opt).data("dd");
		}
	};
	jQuery.fn.extend({
	        msDropDown: function(options)
	        {
	            return this.each(function()
	            {
	               //if (jQuery(this).data('dd')) return; // need to comment when using refresh method - will remove in next version
	               var mydropdown = new dd(this, options);
	               jQuery(this).data('dd', mydropdown);
	            });
	        }
	    });
		   
})(jQuery);