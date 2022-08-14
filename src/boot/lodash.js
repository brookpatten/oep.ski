import { boot } from "quasar/wrappers";
import _ from "lodash-es";

// "async" is optional;
// more info on params: https://v2.quasar.dev/quasar-cli/boot-files
export default boot(({ app }) => {
  //app.use(lodash, VueLodash);
  Vue.prototype.$_ = _;
});
