<template>
  <div class="row">
    <div class="col">
      <div class="q-video">
        <YouTube ref="youtube" :src="'https://www.youtube.com/watch?v=' + selectedVideo.videoId" @ready="ready" width="100%" />
        <!--:height="320"
        width="100%" 
        @ended="onEnded" 
        @paused="onPaused" 
        @played="onPlayed"
        :loop="play.loop" 
        -->
      </div>
    </div>
  </div>
  <div class="row">
    <div class="col col-1"><q-item-label>Turns</q-item-label></div>
    <div class="col col-11">
      <q-btn-group class="float-right">
        <q-btn push label="All" @click="setTimeCode(null)" :color="timeCode === null ? 'primary' : 'info'" />
        <q-btn
          push
          label="2"
          @click="setTimeCode(selectedVideo.timeCodes.twoTurns)"
          :color="timeCode === selectedVideo.timeCodes.twoTurns ? 'primary' : 'info'"
        />
        <q-btn
          push
          label="1"
          @click="setTimeCode(selectedVideo.timeCodes.oneTurn)"
          :color="timeCode === selectedVideo.timeCodes.oneTurn ? 'primary' : 'info'"
        />
        <q-btn
          push
          label="1/3"
          @click="setTimeCode(selectedVideo.timeCodes.initiation)"
          :color="timeCode === selectedVideo.timeCodes.initiation ? 'primary' : 'info'"
        />
        <q-btn
          push
          label="2/3"
          @click="setTimeCode(selectedVideo.timeCodes.shaping)"
          :color="timeCode === selectedVideo.timeCodes.shaping ? 'primary' : 'info'"
        />
        <q-btn
          push
          label="3/3"
          @click="setTimeCode(selectedVideo.timeCodes.finishing)"
          :color="timeCode === selectedVideo.timeCodes.finishing ? 'primary' : 'info'"
        />
      </q-btn-group>
    </div>
  </div>
  <div class="row">
    <div class="col">
      <q-btn-group class="float-right">
        <q-btn push :label="s * 100 + '%'" v-for="s in usefulSpeeds" v-bind:key="s" :color="speed === s ? 'primary' : 'info'" @click="setSpeed(s)" />
      </q-btn-group>
    </div>
  </div>
  <div class="row">
    <div class="col">
      <q-stepper v-model="step" vertical header-nav color="primary" animated>
        <q-step :name="1" title="Turn Shape" icon="settings" :done="step > 1">
          Describe the shape the path the skis take through the snow is forming

          <br />
          <q-btn-group>
            <q-btn
              v-for="shape in glossary.turnShapes"
              v-bind:key="shape.text"
              @click="setTurnShape(shape)"
              :color="answer.turnShape === shape.text ? 'primary' : 'info'"
              >{{ shape.text }}</q-btn
            >
          </q-btn-group>

          <q-stepper-navigation>
            <q-btn @click="step = 2" color="primary" label="Continue" />
          </q-stepper-navigation>
        </q-step>

        <template v-for="phase in glossary.turnPhases" v-bind:key="phase.text">
          <q-step
            :name="1 + (phase.order - 1) * 3 + skiPerformance.order"
            :title="phase.text + ' ' + skiPerformance.text"
            caption=""
            icon="create_new_folder"
            :done="step > 1 + (phase.order - 1) * 3 + skiPerformance.order"
            v-for="skiPerformance in glossary.skiPerformances"
            v-bind:key="skiPerformance.text"
          >
            Describe the {{ skiPerformance.text }} of the ski during the {{ phase.text }} phase of the turn<br />

            {{ JSON.stringify(answer) }}

            <!--<q-checkbox
              v-model="answer.phases[phase.text][skiPerformance.text]"
              :val="e.text"
              :label="e.text"
              v-for="e in getEffects(phase, skiPerformance)"
              v-bind:key="e.text"
            />-->

            <q-stepper-navigation>
              <q-btn @click="step = step == 1 + (phase.order - 1) * 3 + skiPerformance.order ? step + 1 : step" color="primary" label="Continue" />
            </q-stepper-navigation>
          </q-step>
        </template>

        <q-step :name="11" title="Indications" icon="add_comment" :done="step > 11">
          What other indications do you see?<br />

          <q-checkbox v-model="answer.indications" :val="e.text" :label="e.text" v-for="e in glossary.indications" v-bind:key="e.text" />

          <q-stepper-navigation>
            <q-btn @click="step = 12" color="primary" label="Continue" />
          </q-stepper-navigation>
        </q-step>

        <q-step :name="12" title="Cause & Effect" icon="add_comment" :done="step > 12">
          Relate the problem areas you have discovered to their probably cause(s).<br />

          <q-card v-for="group in causeGroups" v-bind:key="group.cause.text">
            <q-card-section>
              <div class="text-subtitle2">{{ group.cause.text }}</div>
            </q-card-section>
            <q-card-section>
              <q-chip v-for="effect in group.effects" v-bind:key="effect.effect.text" :label="effect.effect.text" />
            </q-card-section>
            <q-card-section>
              <q-chip v-for="indication in group.indications" v-bind:key="indication.text" :label="indication.text" />
            </q-card-section>
          </q-card>

          <q-stepper-navigation>
            <q-btn @click="step = 13" color="primary" label="Continue" />
          </q-stepper-navigation>
        </q-step>

        <q-step :name="13" title="Fundamental & Progression" icon="add_comment" :done="step > 13">
          Now that you have established the cause for the skiers inefficiency, build a progression to help coach the skier towards more ideal skiing.

          <q-stepper-navigation>
            <q-btn @click="step = 14" color="primary" label="Continue" />
          </q-stepper-navigation>
        </q-step>

        <q-step :name="14" title="Check your work" icon="add_comment"> Check your work </q-step>
      </q-stepper>

      Answer: {{ JSON.stringify(answer) }}<br />
      Step: {{ JSON.stringify(step) }}<br />

      <!-- place QPageScroller at end of page -->
      <q-page-scroller position="bottom-right" :scroll-offset="150" :offset="[18, 18]">
        <q-btn fab icon="keyboard_arrow_up" color="accent" />
      </q-page-scroller>
    </div>
  </div>
</template>

<script>
import { defineComponent } from 'vue';
import YouTube from 'vue3-youtube';
import { filter } from 'lodash-es';

export default defineComponent({
  name: 'IndexPage',
  components: { YouTube },
  data() {
    return {
      step: 1,
      guided: true,
      timeCode: {},
      speed: 1.0,
      availableSpeeds: [],
      filter: filter,
      glossary: {
        turnShapes: {},
        fundamentals: {},
        skiPerformances: {},
        turnPhases: {},
        indications: {},
        causes: {},
        effects: {},
        drillTypes: {},
        drills: {},
      },
      selectedVideo: {
        videoId: '',
        answerKey: {
          phases: [],
          indications: [],
          causes: [],
          notes: '',
        },
        timeCodes: {
          initiation: { start: 0, end: 0 },
          shaping: { start: 0, end: 0 },
          finishing: { start: 0, end: 0 },
          oneTurn: { start: 0, end: 0 },
          twoTurns: { start: 0, end: 0 },
        },
      },
      answer: {
        turnShape: {},
        effects: [],
        indications: [],
        causes: [],
        fundamentals: [],
        progressions: [],
        notes: '',
      },
      test: [],
      timer: {},
    };
  },
  methods: {
    ready() {
      console.log('ready');
      this.player.mute();
      this.availableSpeeds = this.player.getAvailablePlaybackRates();
      this.player.playVideo();
      console.log(JSON.stringify(this.availableSpeeds) + ' rates');
    },
    tick() {
      //console.log(JSON.stringify(this.availableSpeeds) + " rates");
      if (
        this.timeCode && //a specific time code is actually set
        this.player.getPlayerState() === 1 /*playing*/
      ) {
        //when the player time goes outside of the set time code, set it back to the start of the time code
        if (this.player.getCurrentTime() < this.timeCode.start || this.player.getCurrentTime() > this.timeCode.end) {
          this.player.seekTo(this.timeCode.start, true);
        }
      }
    },
    startTimer() {
      if (this.timer) {
        clearInterval(this.timer);
      }
      this.timer = setInterval(this.tick, 200);
    },
    setTimeCode(code) {
      this.timeCode = code;
      this.startTimer();
    },
    setTurnShape(shape) {
      this.answer.turnShape = shape.text;
    },
    setSpeed(speed) {
      this.speed = speed;
      this.player.setPlaybackRate(this.speed);
    },
    effectCheck(p, perf, phase) {
      alert(JSON.stringify(p) + ' ' + perf + ' ' + phase);
    },
    indicationCheck(p, indication) {
      alert(JSON.stringify(p) + ' ' + indication);
    },
    causeCheck(p, cause) {
      alert(JSON.stringify(p) + ' ' + cause);
    },
    setupGlossary() {
      this.glossary.fundamentals = {
        comBos: {
          text: 'Control the relationship of the Center of Mass to the base of support to direct pressure along the length of the skis',
        },
        outside: {
          text: 'Control pressure from ski to ski and direct pressure toward the outside ski',
        },
        edges: {
          text: 'Control edge angles through a combination of inclination and angulation',
        },
        rotation: {
          text: 'Control the skis rotation (turning, pivoting, steering) with leg rotation, separate from the upper body',
        },
        magnitude: {
          text: 'Regulate the magnitude of pressure created through ski/snow interaction',
        },
      };

      this.glossary.skiPerformances = {
        tipping: { text: 'Tipping', order: 1 },
        twisting: { text: 'Twisting', order: 2 },
        bending: { text: 'Bending', order: 3 },
      };

      this.glossary.turnPhases = {
        initiation: { text: 'Initiation', order: 1 },
        shaping: { text: 'Shaping', order: 2 },
        finishing: { text: 'Finishing', order: 3 },
      };

      this.glossary.causes = {
        leaningOrSittingBack: {
          text: 'Leaning or Sitting back',
          fundamental: this.glossary.fundamentals.comBos,
        },
        tooMuchWeightOnInsideSki: {
          text: 'Too much weight on inside ski',
          fundamental: this.glossary.fundamentals.outside,
        },
        leaningInWithBody: {
          text: 'Leaning/Banking entire Body',
          fundamental: this.glossary.fundamentals.edges,
        },
        narrowStance: {
          text: 'Narrow Stance',
          fundamental: this.glossary.fundamentals.edges,
        },
        turningWithUpperBody: {
          text: 'Turning with upper body movement',
          fundamental: this.glossary.fundamentals.rotation,
        },
        //stiffOutsideLeg: {text:'',effects:[],fundamental:this.glossary.fundamentals.magnitude},
      };

      this.glossary.effects = {
        sequentialTwisting: {
          text: 'Stepped or Sequential Twisting',
          skiPerformances: this.glossary.skiPerformances.twisting,
          phases: [this.glossary.turnPhases.initiation],
          causes: [this.glossary.causes.leaningOrSittingBack, this.glossary.causes.turningWithUpperBody],
        },
        simultaneousTwisting: {
          text: 'Simultaneous Twisting',
          skiPerformances: this.glossary.skiPerformances.twisting,
          causes: [],
        },
        progressiveTwisting: {
          text: 'Progressive Twisting',
          skiPerformances: this.glossary.skiPerformances.twisting,
          causes: [],
        },
        incompleteTwisting: {
          text: 'Incomplete Twisting',
          skiPerformances: this.glossary.skiPerformances.twisting,
          phases: [this.glossary.turnPhases.finishing],
          causes: [],
        },

        minimalEdging: {
          text: 'Minimal Edging',
          skiPerformances: this.glossary.skiPerformances.tipping,
          causes: [this.glossary.causes.leaningInWithBody, this.glossary.causes.narrowStance],
        },
        sequentialEdging: {
          text: 'Sequential Edging',
          skiPerformances: this.glossary.skiPerformances.tipping,
          causes: [this.glossary.causes.leaningInWithBody],
        },
        simultaneousEdging: {
          text: 'Simultaneous Edging',
          skiPerformances: this.glossary.skiPerformances.tipping,
          causes: [],
        },
        progressiveEdging: {
          text: 'Progressive Edging',
          skiPerformances: this.glossary.skiPerformances.tipping,
          causes: [],
        },
        oppositeEdging: {
          text: 'Opposite Edging',
          skiPerformances: this.glossary.skiPerformances.tipping,
          causes: [],
        },
        matchedEdging: {
          text: 'Matched Edging',
          skiPerformances: this.glossary.skiPerformances.tipping,
          causes: [this.glossary.causes.tooMuchWeightOnInsideSki],
        },
        abruptEdging: {
          text: 'Abrupt, non-progressive Edging',
          skiPerformances: this.glossary.skiPerformances.tipping,
          phases: [this.glossary.turnPhases.finishing],
          causes: [],
        },

        tipFlutter: {
          text: 'Tip Flutter',
          skiPerformances: this.glossary.skiPerformances.bending,
          causes: [],
        },
        minimalBending: {
          text: 'No/Minimal Bending',
          skiPerformances: this.glossary.skiPerformances.bending,
          causes: [],
        },
        bootBackBending: {
          text: 'Bending from boot back',
          skiPerformances: this.glossary.skiPerformances.bending,
          causes: [],
        },
        tipToTailBending: {
          text: 'Bending from tip to tail',
          skiPerformances: this.glossary.skiPerformances.bending,
          causes: [],
        },

        insideSkiForward: {
          text: 'Inside Ski excessively forward',
          skiPerformances: this.glossary.skiPerformances.bending,
          causes: [this.glossary.causes.tooMuchWeightOnInsideSki],
        },
        matchedBending: {
          text: 'Matched Bending',
          skiPerformances: this.glossary.skiPerformances.bending,
          causes: [],
        },
        outsideSkiBendingMore: {
          text: 'Outside Ski Slightly more bent than inside ski',
          skiPerformances: this.glossary.skiPerformances.bending,
          causes: [],
        },
      };

      this.glossary.turnShapes = {
        cShape: { text: 'C Shape (Complete)', causes: [] },
        sShape: { text: 'S Shape (Incomplete)', causes: [] },
        jShape: { text: 'J Shape', causes: [] },
        zShape: { text: 'Z Shape', causes: [] },
      };

      this.glossary.indications = {
        lackOfAnkleFlex: {
          text: 'Lack of ankle flex',
          causes: [this.glossary.causes.leaningOrSittingBack],
        },
        tooMuchKneeFlex: {
          text: 'Excessive knee flex',
          causes: [this.glossary.causes.leaningOrSittingBack],
        },
        armsBack: {
          text: 'Arms back or down',
          causes: [this.glossary.causes.leaningOrSittingBack],
        },
        tooMuchHipFlex: {
          text: 'Excessive bending at waist',
          causes: [this.glossary.causes.leaningOrSittingBack],
        },

        inwardLean: {
          text: 'Upper Body leaning inward',
          causes: [this.glossary.causes.tooMuchWeightOnInsideSki, this.glossary.causes.leaningInWithBody],
        },
        lossOfEdgeOnOutsideSki: {
          text: 'Loss of edge on outside ski',
          causes: [this.glossary.causes.tooMuchWeightOnInsideSki],
        },
        skiddingOut: {
          text: 'Skidding Out',
          causes: [this.glossary.causes.tooMuchWeightOnInsideSki, this.glossary.causes.leaningInWithBody, this.glossary.causes.turningWithUpperBody],
        },
        lowInsideHand: {
          text: 'Low Inside Hand',
          causes: [this.glossary.causes.tooMuchWeightOnInsideSki, this.glossary.causes.leaningInWithBody],
        },

        upperBodyTurnsFirst: {
          text: 'Upper body turns first',
          causes: [this.glossary.causes.turningWithUpperBody],
        },
        turningWithHipsOrShoulders: {
          text: 'Turning with Hips or Shoulders',
          causes: [this.glossary.causes.turningWithUpperBody],
        },
        upperBodyMatchesSkiDirection: {
          text: 'Upper Body direction matches ski direction',
          causes: [this.glossary.causes.turningWithUpperBody],
        },
        crossingOutsideHandInFrontOfTheBody: {
          text: 'Crossing Outside hand in front of the body',
          causes: [this.glossary.causes.turningWithUpperBody],
        },

        narrowStance: {
          text: 'Narrow Stance',
          causes: [this.glossary.causes.narrowStance],
          fundamental: this.glossary.fundamentals.edges,
        },
      };

      this.glossary.drillTypes = {
        static: { name: 'Static' },
        simple: { name: 'Simple' },
        complex: { name: 'Complex' },
        skiing: { name: 'Skiing' },
      };

      this.glossary.drills = {
        wedgeChristies: {
          name: 'Wedge Christies',
          type: this.glossary.drillTypes.complex,
          description: '',
          primaryFundamentals: [this.glossary.fundamentals.rotation, this.glossary.fundamentals.outside],
        },
        pivotSlips: {
          name: 'Pivot Slips',
          type: this.glossary.drillTypes.complex,
          description: '',
          primaryFundamentals: [this.glossary.fundamentals.rotation, this.glossary.fundamentals.edges, this.glossary.fundamentals.comBos],
        },
      };
    },
    setupVideo() {
      this.selectedVideo.videoId = 'IvpMe15IQn8';
      this.selectedVideo.answerKey.phases.push({
        phase: this.glossary.turnPhases.initiation,
        effects: [
          this.glossary.effects.simultaneousTwisting,
          this.glossary.effects.minimalEdging,
          this.glossary.effects.tipFlutter,
          this.glossary.effects.minimalBending,
        ],
      });
      this.selectedVideo.answerKey.phases.push({
        phase: this.glossary.turnPhases.shaping,
        effects: [
          this.glossary.effects.simultaneousTwisting,
          this.glossary.effects.minimalEdging,
          this.glossary.effects.tipFlutter,
          this.glossary.effects.minimalBending,
        ],
      });
      this.selectedVideo.answerKey.phases.push({
        phase: this.glossary.turnPhases.finishing,
        effects: [
          this.glossary.effects.simultaneousTwisting,
          this.glossary.effects.incompleteTwisting,
          this.glossary.effects.abruptEdging,
          this.glossary.effects.tipFlutter,
          this.glossary.effects.minimalBending,
        ],
      });
      this.selectedVideo.answerKey.indications.push(this.glossary.indications.narrowStance);
      this.selectedVideo.answerKey.indications.push(this.glossary.indications.skiddingOut);
      this.selectedVideo.answerKey.indications.push(this.glossary.indications.lackOfAnkleFlex);
      this.selectedVideo.answerKey.causes.push(this.glossary.causes.narrowStance);
      this.selectedVideo.answerKey.causes.push(this.glossary.causes.leaningOrSittingBack);
      this.selectedVideo.answerKey.causes.push(this.glossary.causes.tooMuchWeightOnInsideSki);
      this.selectedVideo.answerKey.causes.push(this.glossary.causes.leaningInWithBody);
      this.selectedVideo.timeCodes = {
        initiation: { start: 13.0, end: 15.0 },
        shaping: { start: 15.0, end: 16.0 },
        finishing: { start: 15.5, end: 16.5 },
        oneTurn: { start: 2.0, end: 4.0 },
        twoTurns: { start: 2.0, end: 6.0 },
      };
    },
    setupAnswer() {
      this.answer.turnShape = null;
      this.answer.effects = [];
      this.answer.indications = [];
      this.answer.causes = [];
      this.answer.fundamentals = [];
      this.answer.progressions = [];
    },
    check() {},
    getEffects(turnPhase, skiPerformance) {
      var effects = [];
      for (const [key, value] of Object.entries(this.glossary.effects)) {
        if (value.skiPerformances == skiPerformance && (!value.phases || value.phases.indexOf(turnPhase) >= 0)) {
          effects.push(value);
        }
      }
      return effects;
    },
  },
  computed: {
    player() {
      return this.$refs.youtube.player;
    },
    youTube() {
      return this.$refs.youtube;
    },
    usefulSpeeds() {
      return this.filter(this.availableSpeeds, function (s) {
        return s <= 1.0;
      });
    },

    causeGroups() {
      var causeGroups = [];

      var addCauseGroup = function (cause) {
        for (var i = 0; i < causeGroups.length; i++) {
          if (causeGroups[i].cause == cause) {
            return causeGroups[i];
          }
        }
        var group = { cause, effects: [], indications: [] };
        causeGroups.push(group);
        return group;
      };

      var effects = [];
      for (const [phaseKey, phase] of Object.entries(this.answer.phases)) {
        for (const [spKey, sp] of Object.entries(phase)) {
          for (var ei = 0; ei < sp.length; ei++) {
            var effectText = sp[ei];
            var effect = this.filter(this.glossary.effects, { text: effectText })[0];
            var effectGroup = { effect, phase, skiPerformance: sp };
            effects.push(effectGroup);

            for (var c = 0; c < effect.causes.length; c++) {
              var cause = effect.causes[c];

              var group = addCauseGroup(cause);
              group.effects.push(effectGroup);
            }
          }
        }
      }

      var indications = [];
      for (var ai = 0; ai < this.answer.indications.length; ai++) {
        var indicationText = this.answer.indications[ai];
        var indication = this.filter(this.glossary.indications, { text: indicationText })[0];
        indications.push(indication);

        for (var c = 0; c < indication.causes.length; c++) {
          var cause = indication.causes[c];
          var group = addCauseGroup(cause);
          group.indications.push(indication);
        }
      }

      console.log('found ' + causeGroups.length + ' causes');
      return causeGroups;
    },
  },
  watch: {
    step(s) {
      if (s == 1) {
        this.setTimeCode(this.selectedVideo.timeCodes.twoTurns);
        this.setSpeed(1.0);
      } else if (s >= 2 && s <= 4) {
        this.setTimeCode(this.selectedVideo.timeCodes.initiation);
        this.setSpeed(this.usefulSpeeds[0]);
      } else if (s >= 5 && s <= 7) {
        this.setTimeCode(this.selectedVideo.timeCodes.shaping);
        this.setSpeed(this.usefulSpeeds[0]);
      } else if (s >= 8 && s <= 10) {
        this.setTimeCode(this.selectedVideo.timeCodes.finishing);
        this.setSpeed(this.usefulSpeeds[0]);
      } else if (s == 11) {
        this.setTimeCode(this.selectedVideo.timeCodes.twoTurns);
        this.setSpeed(this.usefulSpeeds[0]);
      } else if (s == 12) {
        this.setTimeCode(this.selectedVideo.timeCodes.twoTurns);
        this.setSpeed(1.0);
      } else if (s == 13) {
        this.setTimeCode(this.selectedVideo.timeCodes.twoTurns);
        this.setSpeed(1.0);
      } else if (s == 14) {
        this.setTimeCode(this.selectedVideo.timeCodes.twoTurns);
        this.setSpeed(1.0);
      }
    },
  },
  mounted: function () {
    this.setupGlossary();
    this.setupVideo();
    this.setupAnswer();
    this.timeCode = null;
  },
});
</script>
