using System.Collections.Generic;
using CringeLazer.Core.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CringeLazer.Bancho.Migrations
{
    public partial class AddPlaystyleAndProfileOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:countries", "unknown,bd,be,bf,bg,ba,bb,wf,bl,bm,bn,bo,bh,bi,bj,bt,jm,bv,bw,ws,bq,br,bs,je,by,bz,ru,rw,rs,tl,re,tm,tj,ro,tk,gw,gu,gt,gs,gr,gq,gp,jp,gy,gg,gf,ge,gd,gb,ga,sv,gn,gm,gl,gi,gh,om,tn,jo,hr,ht,hu,hk,hn,hm,ve,pr,ps,pw,pt,sj,py,iq,pa,pf,pg,pe,pk,ph,pn,pl,pm,zm,eh,ee,eg,za,ec,it,vn,sb,et,so,zw,sa,es,er,me,md,mg,mf,ma,mc,uz,mm,ml,mo,mn,mh,mk,mu,mt,mw,mv,mq,mp,ms,mr,im,ug,tz,my,mx,il,fr,io,sh,fi,fj,fk,fm,fo,ni,nl,no,na,vu,nc,ne,nf,ng,nz,np,nr,nu,ck,xk,ci,ch,co,cn,cm,cl,cc,ca,cg,cf,cd,cz,cy,cx,cr,cw,cv,cu,sz,sy,sx,kg,ke,ss,sr,ki,kh,kn,km,st,sk,kr,si,kp,kw,sn,sm,sl,sc,kz,ky,sg,se,sd,do,dm,dj,dk,vg,de,ye,dz,us,uy,yt,um,lb,lc,la,tv,tw,tt,tr,lk,li,lv,to,lt,lu,lr,ls,th,tf,tg,td,tc,ly,va,vc,ae,ad,ag,af,ai,vi,is,ir,am,al,ao,aq,as,ar,au,at,aw,in,ax,az,ie,id,ua,qa,mz")
                .Annotation("Npgsql:Enum:gamemode", "osu,mania,taiko,fruits")
                .Annotation("Npgsql:Enum:playstyles", "keyboard,mouse,tablet,touch")
                .Annotation("Npgsql:Enum:profile_page", "me,recent_activity,beatmaps,historical,kudosu,top_ranks,medals")
                .OldAnnotation("Npgsql:Enum:countries", "unknown,bd,be,bf,bg,ba,bb,wf,bl,bm,bn,bo,bh,bi,bj,bt,jm,bv,bw,ws,bq,br,bs,je,by,bz,ru,rw,rs,tl,re,tm,tj,ro,tk,gw,gu,gt,gs,gr,gq,gp,jp,gy,gg,gf,ge,gd,gb,ga,sv,gn,gm,gl,gi,gh,om,tn,jo,hr,ht,hu,hk,hn,hm,ve,pr,ps,pw,pt,sj,py,iq,pa,pf,pg,pe,pk,ph,pn,pl,pm,zm,eh,ee,eg,za,ec,it,vn,sb,et,so,zw,sa,es,er,me,md,mg,mf,ma,mc,uz,mm,ml,mo,mn,mh,mk,mu,mt,mw,mv,mq,mp,ms,mr,im,ug,tz,my,mx,il,fr,io,sh,fi,fj,fk,fm,fo,ni,nl,no,na,vu,nc,ne,nf,ng,nz,np,nr,nu,ck,xk,ci,ch,co,cn,cm,cl,cc,ca,cg,cf,cd,cz,cy,cx,cr,cw,cv,cu,sz,sy,sx,kg,ke,ss,sr,ki,kh,kn,km,st,sk,kr,si,kp,kw,sn,sm,sl,sc,kz,ky,sg,se,sd,do,dm,dj,dk,vg,de,ye,dz,us,uy,yt,um,lb,lc,la,tv,tw,tt,tr,lk,li,lv,to,lt,lu,lr,ls,th,tf,tg,td,tc,ly,va,vc,ae,ad,ag,af,ai,vi,is,ir,am,al,ao,aq,as,ar,au,at,aw,in,ax,az,ie,id,ua,qa,mz")
                .OldAnnotation("Npgsql:Enum:gamemode", "osu,mania,taiko,fruits");

            migrationBuilder.AddColumn<string>(
                name: "avatar_url",
                table: "user",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "colour",
                table: "user",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cover_url",
                table: "user",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Gamemode>(
                name: "playmode",
                table: "user",
                type: "gamemode",
                nullable: false,
                defaultValue: Gamemode.Osu);

            migrationBuilder.AddColumn<List<Playstyles>>(
                name: "playstyle",
                table: "user",
                type: "playstyles[]",
                nullable: true);

            migrationBuilder.AddColumn<List<ProfilePage>>(
                name: "profile_order",
                table: "user",
                type: "profile_page[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "avatar_url",
                table: "user");

            migrationBuilder.DropColumn(
                name: "colour",
                table: "user");

            migrationBuilder.DropColumn(
                name: "cover_url",
                table: "user");

            migrationBuilder.DropColumn(
                name: "playmode",
                table: "user");

            migrationBuilder.DropColumn(
                name: "playstyle",
                table: "user");

            migrationBuilder.DropColumn(
                name: "profile_order",
                table: "user");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:countries", "unknown,bd,be,bf,bg,ba,bb,wf,bl,bm,bn,bo,bh,bi,bj,bt,jm,bv,bw,ws,bq,br,bs,je,by,bz,ru,rw,rs,tl,re,tm,tj,ro,tk,gw,gu,gt,gs,gr,gq,gp,jp,gy,gg,gf,ge,gd,gb,ga,sv,gn,gm,gl,gi,gh,om,tn,jo,hr,ht,hu,hk,hn,hm,ve,pr,ps,pw,pt,sj,py,iq,pa,pf,pg,pe,pk,ph,pn,pl,pm,zm,eh,ee,eg,za,ec,it,vn,sb,et,so,zw,sa,es,er,me,md,mg,mf,ma,mc,uz,mm,ml,mo,mn,mh,mk,mu,mt,mw,mv,mq,mp,ms,mr,im,ug,tz,my,mx,il,fr,io,sh,fi,fj,fk,fm,fo,ni,nl,no,na,vu,nc,ne,nf,ng,nz,np,nr,nu,ck,xk,ci,ch,co,cn,cm,cl,cc,ca,cg,cf,cd,cz,cy,cx,cr,cw,cv,cu,sz,sy,sx,kg,ke,ss,sr,ki,kh,kn,km,st,sk,kr,si,kp,kw,sn,sm,sl,sc,kz,ky,sg,se,sd,do,dm,dj,dk,vg,de,ye,dz,us,uy,yt,um,lb,lc,la,tv,tw,tt,tr,lk,li,lv,to,lt,lu,lr,ls,th,tf,tg,td,tc,ly,va,vc,ae,ad,ag,af,ai,vi,is,ir,am,al,ao,aq,as,ar,au,at,aw,in,ax,az,ie,id,ua,qa,mz")
                .Annotation("Npgsql:Enum:gamemode", "osu,mania,taiko,fruits")
                .OldAnnotation("Npgsql:Enum:countries", "unknown,bd,be,bf,bg,ba,bb,wf,bl,bm,bn,bo,bh,bi,bj,bt,jm,bv,bw,ws,bq,br,bs,je,by,bz,ru,rw,rs,tl,re,tm,tj,ro,tk,gw,gu,gt,gs,gr,gq,gp,jp,gy,gg,gf,ge,gd,gb,ga,sv,gn,gm,gl,gi,gh,om,tn,jo,hr,ht,hu,hk,hn,hm,ve,pr,ps,pw,pt,sj,py,iq,pa,pf,pg,pe,pk,ph,pn,pl,pm,zm,eh,ee,eg,za,ec,it,vn,sb,et,so,zw,sa,es,er,me,md,mg,mf,ma,mc,uz,mm,ml,mo,mn,mh,mk,mu,mt,mw,mv,mq,mp,ms,mr,im,ug,tz,my,mx,il,fr,io,sh,fi,fj,fk,fm,fo,ni,nl,no,na,vu,nc,ne,nf,ng,nz,np,nr,nu,ck,xk,ci,ch,co,cn,cm,cl,cc,ca,cg,cf,cd,cz,cy,cx,cr,cw,cv,cu,sz,sy,sx,kg,ke,ss,sr,ki,kh,kn,km,st,sk,kr,si,kp,kw,sn,sm,sl,sc,kz,ky,sg,se,sd,do,dm,dj,dk,vg,de,ye,dz,us,uy,yt,um,lb,lc,la,tv,tw,tt,tr,lk,li,lv,to,lt,lu,lr,ls,th,tf,tg,td,tc,ly,va,vc,ae,ad,ag,af,ai,vi,is,ir,am,al,ao,aq,as,ar,au,at,aw,in,ax,az,ie,id,ua,qa,mz")
                .OldAnnotation("Npgsql:Enum:gamemode", "osu,mania,taiko,fruits")
                .OldAnnotation("Npgsql:Enum:playstyles", "keyboard,mouse,tablet,touch")
                .OldAnnotation("Npgsql:Enum:profile_page", "me,recent_activity,beatmaps,historical,kudosu,top_ranks,medals");
        }
    }
}
