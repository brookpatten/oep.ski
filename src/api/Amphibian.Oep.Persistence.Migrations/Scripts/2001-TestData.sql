declare @systemUserId int;
select @systemUserId = id from users where email='system';

declare @now datetime=getdate();

declare @alpineSkiId int;
select @alpineSkiId = id from snowsports where code='AlpineSki';


insert into videos (videoprovider,videoproviderkey,title,snowsportid,createdbyuserid,createdat)
values ('YouTube','IvpMe15IQn8','L2 BP Practice #2',@alpineSkiId,@systemUserId,@now);

declare @videoId int = scope_identity();


insert into timecodes (videoid,timecodetype,name,startms,endms,[index])
values (@videoId,'Initiation',null,1300,1500,1);

insert into timecodes (videoid,timecodetype,name,startms,endms,[index])
values (@videoId,'Shaping',null,1500,1600,2);

insert into timecodes (videoid,timecodetype,name,startms,endms,[index])
values (@videoId,'Finish',null,1550,1650,3);

insert into timecodes (videoid,timecodetype,name,startms,endms,[index])
values (@videoId,'OneTurn',null,2000,4000,4);

insert into timecodes (videoid,timecodetype,name,startms,endms,[index])
values (@videoId,'TwoTurns',null,2000,6000,5);