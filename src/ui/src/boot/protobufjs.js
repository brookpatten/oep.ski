import { boot } from 'quasar/wrappers';
//import protobufjs from 'protobufjs/minimal';
import { oepski } from '../proto/oepski.proto.js';

// "async" is optional;
// more info on params: https://v2.quasar.dev/quasar-cli/boot-files

export default boot(({ app }) => {
  app.config.globalProperties.$AnswerMessage = oepski.AnswerMessage;
  app.config.globalProperties.$AnswerMessage.base64Encode = function (byteArray) {
    return btoa(
      Array.from(new Uint8Array(byteArray))
        .map((val) => {
          return String.fromCharCode(val);
        })
        .join(''),
    )
      .replace(/\+/g, '-')
      .replace(/\//g, '_')
      .replace(/\=/g, '');
  };
  app.config.globalProperties.$AnswerMessage.base64Decode = function (b64urlstring) {
    return new Uint8Array(
      atob(b64urlstring.replace(/-/g, '+').replace(/_/g, '/'))
        .split('')
        .map((val) => {
          return val.charCodeAt(0);
        }),
    );
  };

  app.config.globalProperties.$AnswerMessage.ToBase64 = function (answer) {
    var message = app.config.globalProperties.$AnswerMessage.fromObject(answer);
    var buffer = app.config.globalProperties.$AnswerMessage.encode(message).finish();
    var base64 = app.config.globalProperties.$AnswerMessage.base64Encode(buffer);
    return base64;
  };

  app.config.globalProperties.$AnswerMessage.FromBase64 = function (p) {
    var buffer = app.config.globalProperties.$AnswerMessage.base64Decode(p);
    var message = app.config.globalProperties.$AnswerMessage.decode(buffer);
    var answer = app.config.globalProperties.$AnswerMessage.toObject(message, { enums: String });
    return answer;
  };

  var payload = { turnShape: 'S_SHAPE', effects: [{ phase: 'initiation', effect: 'outsideSkiBendingMore' }], indications: ['lackOfAnkleFlex'] };
  var base64 = app.config.globalProperties.$AnswerMessage.ToBase64(payload);
  var payload2 = app.config.globalProperties.$AnswerMessage.FromBase64(base64);

  console.info('proto test: ' + JSON.stringify(payload) + ' = ' + base64 + ' = ' + JSON.stringify(payload2));

  // console.info('loaded proto file');

  // var payload = { turnShape: 'jShape', comments: 'test', comments2: null };

  // console.info('object=>json:' + JSON.stringify(payload));

  // //var errMsg = AnswerMessage.verify(payload);
  // //console.error(JSON.stringify(errMsg));

  // var message = AnswerMessage.fromObject(payload, { enums: String });

  // console.info('object=>message=>json ' + JSON.stringify(message));

  // var buffer = AnswerMessage.encode(message).finish();

  // console.info('object=>message=>buffer=>json: ' + JSON.stringify(buffer));

  // var base64 = app.base64Encode(buffer);

  // console.info('object=>message=>buffer=>base64' + JSON.stringify(base64));

  // var decodeBase64 = app.base64Decode(base64);

  // console.info('base64=>buffer=>json: ' + JSON.stringify(decodeBase64));

  // var decoded = AnswerMessage.decode(decodeBase64);

  // console.info('base64=>buffer=>message=>json: ' + JSON.stringify(decoded));

  // var deCreated = AnswerMessage.toObject(decoded, { enums: String });

  // console.info('base64=>buffer=>message=>object=>json: ' + JSON.stringify(deCreated));
});
