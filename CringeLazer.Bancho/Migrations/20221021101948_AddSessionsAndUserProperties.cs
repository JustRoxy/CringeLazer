using System;
using System.Collections.Generic;
using CringeLazer.Core.Enums;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CringeLazer.Bancho.Migrations
{
    public partial class AddSessionsAndUserProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_refresh_token",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "refresh_token",
                table: "user",
                newName: "website");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:countries", "unknown,bd,be,bf,bg,ba,bb,wf,bl,bm,bn,bo,bh,bi,bj,bt,jm,bv,bw,ws,bq,br,bs,je,by,bz,ru,rw,rs,tl,re,tm,tj,ro,tk,gw,gu,gt,gs,gr,gq,gp,jp,gy,gg,gf,ge,gd,gb,ga,sv,gn,gm,gl,gi,gh,om,tn,jo,hr,ht,hu,hk,hn,hm,ve,pr,ps,pw,pt,sj,py,iq,pa,pf,pg,pe,pk,ph,pn,pl,pm,zm,eh,ee,eg,za,ec,it,vn,sb,et,so,zw,sa,es,er,me,md,mg,mf,ma,mc,uz,mm,ml,mo,mn,mh,mk,mu,mt,mw,mv,mq,mp,ms,mr,im,ug,tz,my,mx,il,fr,io,sh,fi,fj,fk,fm,fo,ni,nl,no,na,vu,nc,ne,nf,ng,nz,np,nr,nu,ck,xk,ci,ch,co,cn,cm,cl,cc,ca,cg,cf,cd,cz,cy,cx,cr,cw,cv,cu,sz,sy,sx,kg,ke,ss,sr,ki,kh,kn,km,st,sk,kr,si,kp,kw,sn,sm,sl,sc,kz,ky,sg,se,sd,do,dm,dj,dk,vg,de,ye,dz,us,uy,yt,um,lb,lc,la,tv,tw,tt,tr,lk,li,lv,to,lt,lu,lr,ls,th,tf,tg,td,tc,ly,va,vc,ae,ad,ag,af,ai,vi,is,ir,am,al,ao,aq,as,ar,au,at,aw,in,ax,az,ie,id,ua,qa,mz");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "user",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                table: "user",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<Countries>(
                name: "country",
                table: "user",
                type: "countries",
                nullable: false,
                defaultValue: Countries.Unknown);

            migrationBuilder.AddColumn<string>(
                name: "discord",
                table: "user",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "interests",
                table: "user",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_admin",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_bng",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_bot",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_gmt",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_qat",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_supporter",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "join_date",
                table: "user",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_visit",
                table: "user",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "user",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "occupation",
                table: "user",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "pm_friends_only",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<List<string>>(
                name: "previous_usernames",
                table: "user",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "support_level",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "user",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "twitter",
                table: "user",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "session",
                columns: table => new
                {
                    session_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    refresh_token = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_session", x => x.session_id);
                    table.ForeignKey(
                        name: "FK_session_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_session_refresh_token",
                table: "session",
                column: "refresh_token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_session_user_id",
                table: "session",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "session");

            migrationBuilder.DropColumn(
                name: "country",
                table: "user");

            migrationBuilder.DropColumn(
                name: "discord",
                table: "user");

            migrationBuilder.DropColumn(
                name: "interests",
                table: "user");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "user");

            migrationBuilder.DropColumn(
                name: "is_admin",
                table: "user");

            migrationBuilder.DropColumn(
                name: "is_bng",
                table: "user");

            migrationBuilder.DropColumn(
                name: "is_bot",
                table: "user");

            migrationBuilder.DropColumn(
                name: "is_gmt",
                table: "user");

            migrationBuilder.DropColumn(
                name: "is_qat",
                table: "user");

            migrationBuilder.DropColumn(
                name: "is_supporter",
                table: "user");

            migrationBuilder.DropColumn(
                name: "join_date",
                table: "user");

            migrationBuilder.DropColumn(
                name: "last_visit",
                table: "user");

            migrationBuilder.DropColumn(
                name: "location",
                table: "user");

            migrationBuilder.DropColumn(
                name: "occupation",
                table: "user");

            migrationBuilder.DropColumn(
                name: "pm_friends_only",
                table: "user");

            migrationBuilder.DropColumn(
                name: "previous_usernames",
                table: "user");

            migrationBuilder.DropColumn(
                name: "support_level",
                table: "user");

            migrationBuilder.DropColumn(
                name: "title",
                table: "user");

            migrationBuilder.DropColumn(
                name: "twitter",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "website",
                table: "user",
                newName: "refresh_token");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:countries", "unknown,bd,be,bf,bg,ba,bb,wf,bl,bm,bn,bo,bh,bi,bj,bt,jm,bv,bw,ws,bq,br,bs,je,by,bz,ru,rw,rs,tl,re,tm,tj,ro,tk,gw,gu,gt,gs,gr,gq,gp,jp,gy,gg,gf,ge,gd,gb,ga,sv,gn,gm,gl,gi,gh,om,tn,jo,hr,ht,hu,hk,hn,hm,ve,pr,ps,pw,pt,sj,py,iq,pa,pf,pg,pe,pk,ph,pn,pl,pm,zm,eh,ee,eg,za,ec,it,vn,sb,et,so,zw,sa,es,er,me,md,mg,mf,ma,mc,uz,mm,ml,mo,mn,mh,mk,mu,mt,mw,mv,mq,mp,ms,mr,im,ug,tz,my,mx,il,fr,io,sh,fi,fj,fk,fm,fo,ni,nl,no,na,vu,nc,ne,nf,ng,nz,np,nr,nu,ck,xk,ci,ch,co,cn,cm,cl,cc,ca,cg,cf,cd,cz,cy,cx,cr,cw,cv,cu,sz,sy,sx,kg,ke,ss,sr,ki,kh,kn,km,st,sk,kr,si,kp,kw,sn,sm,sl,sc,kz,ky,sg,se,sd,do,dm,dj,dk,vg,de,ye,dz,us,uy,yt,um,lb,lc,la,tv,tw,tt,tr,lk,li,lv,to,lt,lu,lr,ls,th,tf,tg,td,tc,ly,va,vc,ae,ad,ag,af,ai,vi,is,ir,am,al,ao,aq,as,ar,au,at,aw,in,ax,az,ie,id,ua,qa,mz");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "user",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                table: "user",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_user_refresh_token",
                table: "user",
                column: "refresh_token",
                unique: true);
        }
    }
}
