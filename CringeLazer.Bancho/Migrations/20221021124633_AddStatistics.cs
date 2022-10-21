using System.Collections.Generic;
using CringeLazer.Core.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CringeLazer.Bancho.Migrations
{
    public partial class AddStatistics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:countries", "unknown,bd,be,bf,bg,ba,bb,wf,bl,bm,bn,bo,bh,bi,bj,bt,jm,bv,bw,ws,bq,br,bs,je,by,bz,ru,rw,rs,tl,re,tm,tj,ro,tk,gw,gu,gt,gs,gr,gq,gp,jp,gy,gg,gf,ge,gd,gb,ga,sv,gn,gm,gl,gi,gh,om,tn,jo,hr,ht,hu,hk,hn,hm,ve,pr,ps,pw,pt,sj,py,iq,pa,pf,pg,pe,pk,ph,pn,pl,pm,zm,eh,ee,eg,za,ec,it,vn,sb,et,so,zw,sa,es,er,me,md,mg,mf,ma,mc,uz,mm,ml,mo,mn,mh,mk,mu,mt,mw,mv,mq,mp,ms,mr,im,ug,tz,my,mx,il,fr,io,sh,fi,fj,fk,fm,fo,ni,nl,no,na,vu,nc,ne,nf,ng,nz,np,nr,nu,ck,xk,ci,ch,co,cn,cm,cl,cc,ca,cg,cf,cd,cz,cy,cx,cr,cw,cv,cu,sz,sy,sx,kg,ke,ss,sr,ki,kh,kn,km,st,sk,kr,si,kp,kw,sn,sm,sl,sc,kz,ky,sg,se,sd,do,dm,dj,dk,vg,de,ye,dz,us,uy,yt,um,lb,lc,la,tv,tw,tt,tr,lk,li,lv,to,lt,lu,lr,ls,th,tf,tg,td,tc,ly,va,vc,ae,ad,ag,af,ai,vi,is,ir,am,al,ao,aq,as,ar,au,at,aw,in,ax,az,ie,id,ua,qa,mz")
                .Annotation("Npgsql:Enum:gamemode", "osu,mania,taiko,fruits")
                .OldAnnotation("Npgsql:Enum:countries", "unknown,bd,be,bf,bg,ba,bb,wf,bl,bm,bn,bo,bh,bi,bj,bt,jm,bv,bw,ws,bq,br,bs,je,by,bz,ru,rw,rs,tl,re,tm,tj,ro,tk,gw,gu,gt,gs,gr,gq,gp,jp,gy,gg,gf,ge,gd,gb,ga,sv,gn,gm,gl,gi,gh,om,tn,jo,hr,ht,hu,hk,hn,hm,ve,pr,ps,pw,pt,sj,py,iq,pa,pf,pg,pe,pk,ph,pn,pl,pm,zm,eh,ee,eg,za,ec,it,vn,sb,et,so,zw,sa,es,er,me,md,mg,mf,ma,mc,uz,mm,ml,mo,mn,mh,mk,mu,mt,mw,mv,mq,mp,ms,mr,im,ug,tz,my,mx,il,fr,io,sh,fi,fj,fk,fm,fo,ni,nl,no,na,vu,nc,ne,nf,ng,nz,np,nr,nu,ck,xk,ci,ch,co,cn,cm,cl,cc,ca,cg,cf,cd,cz,cy,cx,cr,cw,cv,cu,sz,sy,sx,kg,ke,ss,sr,ki,kh,kn,km,st,sk,kr,si,kp,kw,sn,sm,sl,sc,kz,ky,sg,se,sd,do,dm,dj,dk,vg,de,ye,dz,us,uy,yt,um,lb,lc,la,tv,tw,tt,tr,lk,li,lv,to,lt,lu,lr,ls,th,tf,tg,td,tc,ly,va,vc,ae,ad,ag,af,ai,vi,is,ir,am,al,ao,aq,as,ar,au,at,aw,in,ax,az,ie,id,ua,qa,mz");

            migrationBuilder.CreateTable(
                name: "statistic",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    gamemode = table.Column<Gamemode>(type: "gamemode", nullable: false),
                    rank_history = table.Column<List<int>>(type: "integer[]", nullable: true),
                    level_current = table.Column<int>(type: "integer", nullable: true),
                    level_progress = table.Column<int>(type: "integer", nullable: true),
                    is_ranked = table.Column<bool>(type: "boolean", nullable: false),
                    global_rank = table.Column<int>(type: "integer", nullable: true),
                    country_rank = table.Column<int>(type: "integer", nullable: true),
                    pp = table.Column<decimal>(type: "numeric", nullable: true),
                    ranked_score = table.Column<long>(type: "bigint", nullable: false),
                    accuracy = table.Column<double>(type: "double precision", nullable: false),
                    playcount = table.Column<int>(type: "integer", nullable: false),
                    playtime = table.Column<int>(type: "integer", nullable: true),
                    total_score = table.Column<long>(type: "bigint", nullable: false),
                    total_hits = table.Column<int>(type: "integer", nullable: false),
                    max_combo = table.Column<int>(type: "integer", nullable: false),
                    replays_watched = table.Column<int>(type: "integer", nullable: false),
                    grades_ssplus = table.Column<int>(type: "integer", nullable: true),
                    grades_ss = table.Column<int>(type: "integer", nullable: true),
                    grades_splus = table.Column<int>(type: "integer", nullable: true),
                    grades_s = table.Column<int>(type: "integer", nullable: true),
                    grades_a = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statistic", x => new { x.user_id, x.gamemode });
                    table.ForeignKey(
                        name: "FK_statistic_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "statistic");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:countries", "unknown,bd,be,bf,bg,ba,bb,wf,bl,bm,bn,bo,bh,bi,bj,bt,jm,bv,bw,ws,bq,br,bs,je,by,bz,ru,rw,rs,tl,re,tm,tj,ro,tk,gw,gu,gt,gs,gr,gq,gp,jp,gy,gg,gf,ge,gd,gb,ga,sv,gn,gm,gl,gi,gh,om,tn,jo,hr,ht,hu,hk,hn,hm,ve,pr,ps,pw,pt,sj,py,iq,pa,pf,pg,pe,pk,ph,pn,pl,pm,zm,eh,ee,eg,za,ec,it,vn,sb,et,so,zw,sa,es,er,me,md,mg,mf,ma,mc,uz,mm,ml,mo,mn,mh,mk,mu,mt,mw,mv,mq,mp,ms,mr,im,ug,tz,my,mx,il,fr,io,sh,fi,fj,fk,fm,fo,ni,nl,no,na,vu,nc,ne,nf,ng,nz,np,nr,nu,ck,xk,ci,ch,co,cn,cm,cl,cc,ca,cg,cf,cd,cz,cy,cx,cr,cw,cv,cu,sz,sy,sx,kg,ke,ss,sr,ki,kh,kn,km,st,sk,kr,si,kp,kw,sn,sm,sl,sc,kz,ky,sg,se,sd,do,dm,dj,dk,vg,de,ye,dz,us,uy,yt,um,lb,lc,la,tv,tw,tt,tr,lk,li,lv,to,lt,lu,lr,ls,th,tf,tg,td,tc,ly,va,vc,ae,ad,ag,af,ai,vi,is,ir,am,al,ao,aq,as,ar,au,at,aw,in,ax,az,ie,id,ua,qa,mz")
                .OldAnnotation("Npgsql:Enum:countries", "unknown,bd,be,bf,bg,ba,bb,wf,bl,bm,bn,bo,bh,bi,bj,bt,jm,bv,bw,ws,bq,br,bs,je,by,bz,ru,rw,rs,tl,re,tm,tj,ro,tk,gw,gu,gt,gs,gr,gq,gp,jp,gy,gg,gf,ge,gd,gb,ga,sv,gn,gm,gl,gi,gh,om,tn,jo,hr,ht,hu,hk,hn,hm,ve,pr,ps,pw,pt,sj,py,iq,pa,pf,pg,pe,pk,ph,pn,pl,pm,zm,eh,ee,eg,za,ec,it,vn,sb,et,so,zw,sa,es,er,me,md,mg,mf,ma,mc,uz,mm,ml,mo,mn,mh,mk,mu,mt,mw,mv,mq,mp,ms,mr,im,ug,tz,my,mx,il,fr,io,sh,fi,fj,fk,fm,fo,ni,nl,no,na,vu,nc,ne,nf,ng,nz,np,nr,nu,ck,xk,ci,ch,co,cn,cm,cl,cc,ca,cg,cf,cd,cz,cy,cx,cr,cw,cv,cu,sz,sy,sx,kg,ke,ss,sr,ki,kh,kn,km,st,sk,kr,si,kp,kw,sn,sm,sl,sc,kz,ky,sg,se,sd,do,dm,dj,dk,vg,de,ye,dz,us,uy,yt,um,lb,lc,la,tv,tw,tt,tr,lk,li,lv,to,lt,lu,lr,ls,th,tf,tg,td,tc,ly,va,vc,ae,ad,ag,af,ai,vi,is,ir,am,al,ao,aq,as,ar,au,at,aw,in,ax,az,ie,id,ua,qa,mz")
                .OldAnnotation("Npgsql:Enum:gamemode", "osu,mania,taiko,fruits");
        }
    }
}
