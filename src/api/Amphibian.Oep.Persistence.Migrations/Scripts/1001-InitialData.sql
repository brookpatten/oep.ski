--system user
declare @systemUserId int;
insert into users(email,firstname,lastname) values ('system','system','system');
set @systemUserId = scope_identity();

declare @now datetime=getdate();

--fundamentals
--1
insert into fundamentals (code,text,[index],snowsport)
values ('comBos','Control the relationship of the Center of Mass to the base of support to direct pressure along the length of the skis',1,'AlpineSki');
--2
insert into fundamentals (code,text,[index],snowsport)
values ('outsideSki','Control pressure from ski to ski and direct pressure toward the outside ski',2,'AlpineSki');
--3
insert into fundamentals (code,text,[index],snowsport)
values ('edgeAngle','Control edge angles through a combination of inclination and angulation',3,'AlpineSki');
--4
insert into fundamentals (code,text,[index],snowsport)
values ('rotation','Control the skis rotation (turning, pivoting, steering) with leg rotation, separate from the upper body',4,'AlpineSki');
--5
insert into fundamentals (code,text,[index],snowsport)
values ('magnitude','Regulate the magnitude of pressure created through ski/snow interaction',5,'AlpineSki');



--causes
--1
insert into causes (code,text,[index],snowsport,createdbyuserid,createdat,acceptedat)
values('leaningOrSittingBack','Leaning or Sitting back',1,'AlpineSki',@systemUserId,@now,@now);
--2
insert into causes (code,text,[index],snowsport,createdbyuserid,createdat,acceptedat)
values('tooMuchWeightOnInsideSki','Too much weight on inside ski',2,'AlpineSki',@systemUserId,@now,@now);
--3
insert into causes (code,text,[index],snowsport,createdbyuserid,createdat,acceptedat)
values('leaningInWithBody','Leaning/Banking entire Body',3,'AlpineSki',@systemUserId,@now,@now);
--4
insert into causes (code,text,[index],snowsport,createdbyuserid,createdat,acceptedat)
values('narrowStance','Narrow Stance',4,'AlpineSki',@systemUserId,@now,@now);
--5
insert into causes (code,text,[index],snowsport,createdbyuserid,createdat,acceptedat)
values('turningWithUpperBody','Turning with upper body movement',5,'AlpineSki',@systemUserId,@now,@now);

--observations: ski performance: twisting
--1
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('sequentialTwisting','Stepped or Sequential Twisting',1,'SkiPerformance','Twisting','Initation','AlpineSki',@systemUserId,@now,@now);
--2
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('simultaneousTwisting','Simultaneous Twisting',2,'SkiPerformance','Twisting',null,'AlpineSki',@systemUserId,@now,@now);
--3
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('progressiveTwisting','Progressive Twisting',3,'SkiPerformance','Twisting',null,'AlpineSki',@systemUserId,@now,@now);
--4
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('incompleteTwisting','Incomplete Twisting',4,'SkiPerformance','Twisting','Finishing','AlpineSki',@systemUserId,@now,@now);

--observations: ski performance: tipping
--5
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('minimalEdging','Minimal Edging',5,'SkiPerformance','Tipping',null,'AlpineSki',@systemUserId,@now,@now);
--6
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('sequentialEdging','Sequential Edging',6,'SkiPerformance','Tipping',null,'AlpineSki',@systemUserId,@now,@now);
--7
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('simultaneousEdging','Simultaneous Edging',7,'SkiPerformance','Tipping',null,'AlpineSki',@systemUserId,@now,@now);
--8
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('progressiveEdging','Progressive Edging',8,'SkiPerformance','Tipping',null,'AlpineSki',@systemUserId,@now,@now);
--9
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('oppositeEdging','Opposite Edging',9,'SkiPerformance','Tipping',null,'AlpineSki',@systemUserId,@now,@now);
--10
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('matchedEdging','Matched Edging',10,'SkiPerformance','Tipping',null,'AlpineSki',@systemUserId,@now,@now);
--11
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('abruptEdging','Abrupt, non-progressive Edging',11,'SkiPerformance','Tipping','Finishing','AlpineSki',@systemUserId,@now,@now);

--observations: ski performance: bending
--12
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('tipFlutter','Tip Flutter',12,'SkiPerformance','Bending',null,'AlpineSki',@systemUserId,@now,@now);
--13
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('minimalBending','No/Minimal Bending',13,'SkiPerformance','Bending',null,'AlpineSki',@systemUserId,@now,@now);
--14
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('bootBackBending','Bending from boot back',14,'SkiPerformance','Bending',null,'AlpineSki',@systemUserId,@now,@now);
--15
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('tipToTailBending','Bending from tip to tail',15,'SkiPerformance','Bending',null,'AlpineSki',@systemUserId,@now,@now);
--16
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('insideSkiForward','Inside Ski excessively forward',16,'SkiPerformance','Bending',null,'AlpineSki',@systemUserId,@now,@now);
--17
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('matchedBending','Matched Bending',17,'SkiPerformance','Bending',null,'AlpineSki',@systemUserId,@now,@now);
--18
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('outsideSkiBendingMore','Outside Ski Slightly more bent than inside ski',18,'SkiPerformance','Bending',null,'AlpineSki',@systemUserId,@now,@now);

--aggregate out turn phases where phase wasn't specified
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
select code+'Initiation',text,[index],category,skiperformance,'Initiation',snowsport,createdbyuserid,createdat,acceptedat
from observations where category='SkiPerformance' and turnphase is null;

insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
select code+'Shaping',text,[index],category,skiperformance,'Shaping',snowsport,createdbyuserid,createdat,acceptedat
from observations where category='SkiPerformance' and turnphase is null;

insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
select code+'Finish',text,[index],category,skiperformance,'Finish',snowsport,createdbyuserid,createdat,acceptedat
from observations where category='SkiPerformance' and turnphase is null;
--delete where turn phases weren't specified
delete from observations where category='SkiPerformance' and turnphase is null;

--observations: turn shapes
--19
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('cShape','C Shape (Complete)',19,'TurnShape',null,null,'AlpineSki',@systemUserId,@now,@now);
--20
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('sShape','S Shape (Incomplete)',20,'TurnShape',null,null,'AlpineSki',@systemUserId,@now,@now);
--21
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('jShape','J Shape',21,'TurnShape',null,null,'AlpineSki',@systemUserId,@now,@now);
--22
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('zShape','Z Shape',22,'TurnShape',null,null,'AlpineSki',@systemUserId,@now,@now);

--observations: body indications
--23
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('lackOfAnkleFlex','Lack of ankle flex',23,'BodyIndication',null,null,'AlpineSki',@systemUserId,@now,@now);
--24
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('tooMuchKneeFlex','Excessive knee flex',24,'BodyIndication',null,null,'AlpineSki',@systemUserId,@now,@now);
--25
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('armsBack','Arms back or down',25,'BodyIndication',null,null,'AlpineSki',@systemUserId,@now,@now);
--26
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('tooMuchHipFlex','Excessive bending at waist',26,'BodyIndication',null,null,'AlpineSki',@systemUserId,@now,@now);
--27
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('inwardLean','Upper Body leaning inward',27,'BodyIndication',null,null,'AlpineSki',@systemUserId,@now,@now);
--28
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('lossOfEdgeOnOutsideSki','Loss of edge on outside ski',28,'BodyIndication',null,null,'AlpineSki',@systemUserId,@now,@now);
--29
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('skiddingOut','Skidding Out',29,'BodyIndication',null,null,'AlpineSki',@systemUserId,@now,@now);
--30
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('lowInsideHand','Low Inside Hand',30,'BodyIndication',null,null,'AlpineSki',@systemUserId,@now,@now);
--31
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('upperBodyTurnsFirst','Upper body turns first',31,'BodyIndication',null,null,'AlpineSki',@systemUserId,@now,@now);
--32
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('turningWithHipsOrShoulders','Turning with Hips or Shoulders',32,'BodyIndication',null,null,'AlpineSki',@systemUserId,@now,@now);
--33
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('upperBodyMatchesSkiDirection','Upper Body direction matches ski direction',33,'BodyIndication',null,null,'AlpineSki',@systemUserId,@now,@now);
--34
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('crossingOutsideHandInFrontOfTheBody','Crossing Outside hand in front of the body',34,'BodyIndication',null,null,'AlpineSki',@systemUserId,@now,@now);
--35
insert into observations (code,text,[index],category,skiperformance,turnphase,snowsport,createdbyuserid,createdat,acceptedat)
values ('narrowStance','Narrow Stance',35,'BodyIndication',null,null,'AlpineSki',@systemUserId,@now,@now);

--causes
insert into causesuggestions (observationid,causeid)
select o.id,c.id
from observations o
inner join causes c on 
(o.code='lackOfAnkleFlex' and c.code='leaningOrSittingBack') or
(o.code='tooMuchKneeFlex' and c.code='leaningOrSittingBack') or
(o.code='armsBack' and c.code='leaningOrSittingBack') or
(o.code='tooMuchHipFlex' and c.code='leaningOrSittingBack') or
(o.code='inwardLean' and c.code='tooMuchWeightOnInsideSki') or
(o.code='inwardLean' and c.code='leaningInWithBody') or
(o.code='lossOfEdgeOnOutsideSki' and c.code='tooMuchWeightOnInsideSki') or
(o.code='skiddingOut' and c.code='tooMuchWeightOnInsideSki') or
(o.code='skiddingOut' and c.code='leaningInWithBody') or
(o.code='skiddingOut' and c.code='turningWithUpperBody') or
(o.code='lowInsideHand' and c.code='tooMuchWeightOnInsideSki') or
(o.code='lowInsideHand' and c.code='leaningInWithBody') or
(o.code='upperBodyTurnsFirst' and c.code='turningWithUpperBody') or
(o.code='turningWithHipsOrShoulders' and c.code='turningWithUpperBody') or
(o.code='upperBodyMatchesSkiDirection' and c.code='turningWithUpperBody') or
(o.code='crossingOutsideHandInFrontOfTheBody' and c.code='turningWithUpperBody') or
(o.code='narrowStance' and c.code='narrowStance') or
(o.code='sequentialTwisting' and c.code='leaningOrSittingBack') or
(o.code='sequentialTwisting' and c.code='turningWithUpperBody') or
(o.code='incompleteTwisting' and c.code='') or
(o.code='minimalEdging' and c.code='leaningInWithBody') or
(o.code='minimalEdging' and c.code='narrowStance') or
(o.code='sequentialEdging' and c.code='leaningInWithBody') or
(o.code='abruptEdging' and c.code='leaningOrSittingBack') or
(o.code='tipFlutter' and c.code='leaningOrSittingBack') or
(o.code='bootBackBending' and c.code='leaningOrSittingBack') or
(o.code='insideSkiForward' and c.code='turningWithUpperBody') or
(o.code='zShape' and c.code='leaningOrSittingBack') or
(o.code='jShape' and c.code='leaningOrSittingBack');

insert into fundamentalsuggestions (causeid,fundamentalid)
select c.id,f.id
from causes c
inner join fundamentals f on
(c.code='leaningOrSittingBack' and f.code='comBos') or
(c.code='tooMuchWeightOnInsideSki' and f.code='outsideSki') or
(c.code='leaningInWithBody' and f.code='edgeAngle') or
(c.code='narrowStance' and f.code='edgeAngle') or
(c.code='turningWithUpperBody' and f.code='rotation');