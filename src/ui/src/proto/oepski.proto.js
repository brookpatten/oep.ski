/*eslint-disable block-scoped-var, id-length, no-control-regex, no-magic-numbers, no-prototype-builtins, no-redeclare, no-shadow, no-var, sort-vars*/
import * as $protobuf from "protobufjs/minimal";

// Common aliases
const $Reader = $protobuf.Reader, $Writer = $protobuf.Writer, $util = $protobuf.util;

// Exported root namespace
const $root = $protobuf.roots["default"] || ($protobuf.roots["default"] = {});

export const oepski = $root.oepski = (() => {

    /**
     * Namespace oepski.
     * @exports oepski
     * @namespace
     */
    const oepski = {};

    /**
     * TurnShape enum.
     * @name oepski.TurnShape
     * @enum {number}
     * @property {number} UNSPECIFIED=0 UNSPECIFIED value
     * @property {number} C_SHAPE=1 C_SHAPE value
     * @property {number} S_SHAPE=2 S_SHAPE value
     * @property {number} J_SHAPE=3 J_SHAPE value
     * @property {number} Z_SHAPE=4 Z_SHAPE value
     */
    oepski.TurnShape = (function() {
        const valuesById = {}, values = Object.create(valuesById);
        values[valuesById[0] = "UNSPECIFIED"] = 0;
        values[valuesById[1] = "C_SHAPE"] = 1;
        values[valuesById[2] = "S_SHAPE"] = 2;
        values[valuesById[3] = "J_SHAPE"] = 3;
        values[valuesById[4] = "Z_SHAPE"] = 4;
        return values;
    })();

    /**
     * Effect enum.
     * @name oepski.Effect
     * @enum {number}
     * @property {number} UNSPECIFIED=0 UNSPECIFIED value
     * @property {number} sequentialTwisting=1 sequentialTwisting value
     * @property {number} simultaneousTwisting=2 simultaneousTwisting value
     * @property {number} progressiveTwisting=3 progressiveTwisting value
     * @property {number} incompleteTwisting=4 incompleteTwisting value
     * @property {number} minimalEdging=5 minimalEdging value
     * @property {number} sequentialEdging=6 sequentialEdging value
     * @property {number} simultaneousEdging=7 simultaneousEdging value
     * @property {number} progressiveEdging=8 progressiveEdging value
     * @property {number} oppositeEdging=9 oppositeEdging value
     * @property {number} matchedEdging=10 matchedEdging value
     * @property {number} abruptEdging=11 abruptEdging value
     * @property {number} tipFlutter=12 tipFlutter value
     * @property {number} minimalBending=13 minimalBending value
     * @property {number} bootBackBending=14 bootBackBending value
     * @property {number} tipToTailBending=15 tipToTailBending value
     * @property {number} insideSkiForward=16 insideSkiForward value
     * @property {number} matchedBending=17 matchedBending value
     * @property {number} outsideSkiBendingMore=18 outsideSkiBendingMore value
     */
    oepski.Effect = (function() {
        const valuesById = {}, values = Object.create(valuesById);
        values[valuesById[0] = "UNSPECIFIED"] = 0;
        values[valuesById[1] = "sequentialTwisting"] = 1;
        values[valuesById[2] = "simultaneousTwisting"] = 2;
        values[valuesById[3] = "progressiveTwisting"] = 3;
        values[valuesById[4] = "incompleteTwisting"] = 4;
        values[valuesById[5] = "minimalEdging"] = 5;
        values[valuesById[6] = "sequentialEdging"] = 6;
        values[valuesById[7] = "simultaneousEdging"] = 7;
        values[valuesById[8] = "progressiveEdging"] = 8;
        values[valuesById[9] = "oppositeEdging"] = 9;
        values[valuesById[10] = "matchedEdging"] = 10;
        values[valuesById[11] = "abruptEdging"] = 11;
        values[valuesById[12] = "tipFlutter"] = 12;
        values[valuesById[13] = "minimalBending"] = 13;
        values[valuesById[14] = "bootBackBending"] = 14;
        values[valuesById[15] = "tipToTailBending"] = 15;
        values[valuesById[16] = "insideSkiForward"] = 16;
        values[valuesById[17] = "matchedBending"] = 17;
        values[valuesById[18] = "outsideSkiBendingMore"] = 18;
        return values;
    })();

    /**
     * Indication enum.
     * @name oepski.Indication
     * @enum {number}
     * @property {number} UNSPECIFIED=0 UNSPECIFIED value
     * @property {number} lackOfAnkleFlex=1 lackOfAnkleFlex value
     * @property {number} tooMuchKneeFlex=2 tooMuchKneeFlex value
     * @property {number} armsBack=3 armsBack value
     * @property {number} tooMuchHipFlex=4 tooMuchHipFlex value
     * @property {number} inwardLean=5 inwardLean value
     * @property {number} lossOfEdgeOnOutsideSki=6 lossOfEdgeOnOutsideSki value
     * @property {number} skiddingOut=7 skiddingOut value
     * @property {number} lowInsideHand=8 lowInsideHand value
     * @property {number} upperBodyTurnsFirst=9 upperBodyTurnsFirst value
     * @property {number} turningWithHipsOrShoulders=10 turningWithHipsOrShoulders value
     * @property {number} upperBodyMatchesSkiDirection=11 upperBodyMatchesSkiDirection value
     * @property {number} crossingOutsideHandInFrontOfTheBody=12 crossingOutsideHandInFrontOfTheBody value
     * @property {number} narrowStance=13 narrowStance value
     */
    oepski.Indication = (function() {
        const valuesById = {}, values = Object.create(valuesById);
        values[valuesById[0] = "UNSPECIFIED"] = 0;
        values[valuesById[1] = "lackOfAnkleFlex"] = 1;
        values[valuesById[2] = "tooMuchKneeFlex"] = 2;
        values[valuesById[3] = "armsBack"] = 3;
        values[valuesById[4] = "tooMuchHipFlex"] = 4;
        values[valuesById[5] = "inwardLean"] = 5;
        values[valuesById[6] = "lossOfEdgeOnOutsideSki"] = 6;
        values[valuesById[7] = "skiddingOut"] = 7;
        values[valuesById[8] = "lowInsideHand"] = 8;
        values[valuesById[9] = "upperBodyTurnsFirst"] = 9;
        values[valuesById[10] = "turningWithHipsOrShoulders"] = 10;
        values[valuesById[11] = "upperBodyMatchesSkiDirection"] = 11;
        values[valuesById[12] = "crossingOutsideHandInFrontOfTheBody"] = 12;
        values[valuesById[13] = "narrowStance"] = 13;
        return values;
    })();

    /**
     * Phase enum.
     * @name oepski.Phase
     * @enum {number}
     * @property {number} UNSPECIFIED=0 UNSPECIFIED value
     * @property {number} initiation=1 initiation value
     * @property {number} shaping=2 shaping value
     * @property {number} finishing=3 finishing value
     */
    oepski.Phase = (function() {
        const valuesById = {}, values = Object.create(valuesById);
        values[valuesById[0] = "UNSPECIFIED"] = 0;
        values[valuesById[1] = "initiation"] = 1;
        values[valuesById[2] = "shaping"] = 2;
        values[valuesById[3] = "finishing"] = 3;
        return values;
    })();

    oepski.PhaseEffect = (function() {

        /**
         * Properties of a PhaseEffect.
         * @memberof oepski
         * @interface IPhaseEffect
         * @property {oepski.Phase|null} [phase] PhaseEffect phase
         * @property {oepski.Effect|null} [effect] PhaseEffect effect
         */

        /**
         * Constructs a new PhaseEffect.
         * @memberof oepski
         * @classdesc Represents a PhaseEffect.
         * @implements IPhaseEffect
         * @constructor
         * @param {oepski.IPhaseEffect=} [properties] Properties to set
         */
        function PhaseEffect(properties) {
            if (properties)
                for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                    if (properties[keys[i]] != null)
                        this[keys[i]] = properties[keys[i]];
        }

        /**
         * PhaseEffect phase.
         * @member {oepski.Phase} phase
         * @memberof oepski.PhaseEffect
         * @instance
         */
        PhaseEffect.prototype.phase = 0;

        /**
         * PhaseEffect effect.
         * @member {oepski.Effect} effect
         * @memberof oepski.PhaseEffect
         * @instance
         */
        PhaseEffect.prototype.effect = 0;

        /**
         * Creates a new PhaseEffect instance using the specified properties.
         * @function create
         * @memberof oepski.PhaseEffect
         * @static
         * @param {oepski.IPhaseEffect=} [properties] Properties to set
         * @returns {oepski.PhaseEffect} PhaseEffect instance
         */
        PhaseEffect.create = function create(properties) {
            return new PhaseEffect(properties);
        };

        /**
         * Encodes the specified PhaseEffect message. Does not implicitly {@link oepski.PhaseEffect.verify|verify} messages.
         * @function encode
         * @memberof oepski.PhaseEffect
         * @static
         * @param {oepski.IPhaseEffect} message PhaseEffect message or plain object to encode
         * @param {$protobuf.Writer} [writer] Writer to encode to
         * @returns {$protobuf.Writer} Writer
         */
        PhaseEffect.encode = function encode(message, writer) {
            if (!writer)
                writer = $Writer.create();
            if (message.phase != null && Object.hasOwnProperty.call(message, "phase"))
                writer.uint32(/* id 0, wireType 0 =*/0).int32(message.phase);
            if (message.effect != null && Object.hasOwnProperty.call(message, "effect"))
                writer.uint32(/* id 1, wireType 0 =*/8).int32(message.effect);
            return writer;
        };

        /**
         * Encodes the specified PhaseEffect message, length delimited. Does not implicitly {@link oepski.PhaseEffect.verify|verify} messages.
         * @function encodeDelimited
         * @memberof oepski.PhaseEffect
         * @static
         * @param {oepski.IPhaseEffect} message PhaseEffect message or plain object to encode
         * @param {$protobuf.Writer} [writer] Writer to encode to
         * @returns {$protobuf.Writer} Writer
         */
        PhaseEffect.encodeDelimited = function encodeDelimited(message, writer) {
            return this.encode(message, writer).ldelim();
        };

        /**
         * Decodes a PhaseEffect message from the specified reader or buffer.
         * @function decode
         * @memberof oepski.PhaseEffect
         * @static
         * @param {$protobuf.Reader|Uint8Array} reader Reader or buffer to decode from
         * @param {number} [length] Message length if known beforehand
         * @returns {oepski.PhaseEffect} PhaseEffect
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        PhaseEffect.decode = function decode(reader, length) {
            if (!(reader instanceof $Reader))
                reader = $Reader.create(reader);
            let end = length === undefined ? reader.len : reader.pos + length, message = new $root.oepski.PhaseEffect();
            while (reader.pos < end) {
                let tag = reader.uint32();
                switch (tag >>> 3) {
                case 0: {
                        message.phase = reader.int32();
                        break;
                    }
                case 1: {
                        message.effect = reader.int32();
                        break;
                    }
                default:
                    reader.skipType(tag & 7);
                    break;
                }
            }
            return message;
        };

        /**
         * Decodes a PhaseEffect message from the specified reader or buffer, length delimited.
         * @function decodeDelimited
         * @memberof oepski.PhaseEffect
         * @static
         * @param {$protobuf.Reader|Uint8Array} reader Reader or buffer to decode from
         * @returns {oepski.PhaseEffect} PhaseEffect
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        PhaseEffect.decodeDelimited = function decodeDelimited(reader) {
            if (!(reader instanceof $Reader))
                reader = new $Reader(reader);
            return this.decode(reader, reader.uint32());
        };

        /**
         * Verifies a PhaseEffect message.
         * @function verify
         * @memberof oepski.PhaseEffect
         * @static
         * @param {Object.<string,*>} message Plain object to verify
         * @returns {string|null} `null` if valid, otherwise the reason why it is not
         */
        PhaseEffect.verify = function verify(message) {
            if (typeof message !== "object" || message === null)
                return "object expected";
            if (message.phase != null && message.hasOwnProperty("phase"))
                switch (message.phase) {
                default:
                    return "phase: enum value expected";
                case 0:
                case 1:
                case 2:
                case 3:
                    break;
                }
            if (message.effect != null && message.hasOwnProperty("effect"))
                switch (message.effect) {
                default:
                    return "effect: enum value expected";
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                    break;
                }
            return null;
        };

        /**
         * Creates a PhaseEffect message from a plain object. Also converts values to their respective internal types.
         * @function fromObject
         * @memberof oepski.PhaseEffect
         * @static
         * @param {Object.<string,*>} object Plain object
         * @returns {oepski.PhaseEffect} PhaseEffect
         */
        PhaseEffect.fromObject = function fromObject(object) {
            if (object instanceof $root.oepski.PhaseEffect)
                return object;
            let message = new $root.oepski.PhaseEffect();
            switch (object.phase) {
            default:
                if (typeof object.phase === "number") {
                    message.phase = object.phase;
                    break;
                }
                break;
            case "UNSPECIFIED":
            case 0:
                message.phase = 0;
                break;
            case "initiation":
            case 1:
                message.phase = 1;
                break;
            case "shaping":
            case 2:
                message.phase = 2;
                break;
            case "finishing":
            case 3:
                message.phase = 3;
                break;
            }
            switch (object.effect) {
            default:
                if (typeof object.effect === "number") {
                    message.effect = object.effect;
                    break;
                }
                break;
            case "UNSPECIFIED":
            case 0:
                message.effect = 0;
                break;
            case "sequentialTwisting":
            case 1:
                message.effect = 1;
                break;
            case "simultaneousTwisting":
            case 2:
                message.effect = 2;
                break;
            case "progressiveTwisting":
            case 3:
                message.effect = 3;
                break;
            case "incompleteTwisting":
            case 4:
                message.effect = 4;
                break;
            case "minimalEdging":
            case 5:
                message.effect = 5;
                break;
            case "sequentialEdging":
            case 6:
                message.effect = 6;
                break;
            case "simultaneousEdging":
            case 7:
                message.effect = 7;
                break;
            case "progressiveEdging":
            case 8:
                message.effect = 8;
                break;
            case "oppositeEdging":
            case 9:
                message.effect = 9;
                break;
            case "matchedEdging":
            case 10:
                message.effect = 10;
                break;
            case "abruptEdging":
            case 11:
                message.effect = 11;
                break;
            case "tipFlutter":
            case 12:
                message.effect = 12;
                break;
            case "minimalBending":
            case 13:
                message.effect = 13;
                break;
            case "bootBackBending":
            case 14:
                message.effect = 14;
                break;
            case "tipToTailBending":
            case 15:
                message.effect = 15;
                break;
            case "insideSkiForward":
            case 16:
                message.effect = 16;
                break;
            case "matchedBending":
            case 17:
                message.effect = 17;
                break;
            case "outsideSkiBendingMore":
            case 18:
                message.effect = 18;
                break;
            }
            return message;
        };

        /**
         * Creates a plain object from a PhaseEffect message. Also converts values to other types if specified.
         * @function toObject
         * @memberof oepski.PhaseEffect
         * @static
         * @param {oepski.PhaseEffect} message PhaseEffect
         * @param {$protobuf.IConversionOptions} [options] Conversion options
         * @returns {Object.<string,*>} Plain object
         */
        PhaseEffect.toObject = function toObject(message, options) {
            if (!options)
                options = {};
            let object = {};
            if (options.defaults) {
                object.phase = options.enums === String ? "UNSPECIFIED" : 0;
                object.effect = options.enums === String ? "UNSPECIFIED" : 0;
            }
            if (message.phase != null && message.hasOwnProperty("phase"))
                object.phase = options.enums === String ? $root.oepski.Phase[message.phase] === undefined ? message.phase : $root.oepski.Phase[message.phase] : message.phase;
            if (message.effect != null && message.hasOwnProperty("effect"))
                object.effect = options.enums === String ? $root.oepski.Effect[message.effect] === undefined ? message.effect : $root.oepski.Effect[message.effect] : message.effect;
            return object;
        };

        /**
         * Converts this PhaseEffect to JSON.
         * @function toJSON
         * @memberof oepski.PhaseEffect
         * @instance
         * @returns {Object.<string,*>} JSON object
         */
        PhaseEffect.prototype.toJSON = function toJSON() {
            return this.constructor.toObject(this, $protobuf.util.toJSONOptions);
        };

        /**
         * Gets the default type url for PhaseEffect
         * @function getTypeUrl
         * @memberof oepski.PhaseEffect
         * @static
         * @param {string} [typeUrlPrefix] your custom typeUrlPrefix(default "type.googleapis.com")
         * @returns {string} The default type url
         */
        PhaseEffect.getTypeUrl = function getTypeUrl(typeUrlPrefix) {
            if (typeUrlPrefix === undefined) {
                typeUrlPrefix = "type.googleapis.com";
            }
            return typeUrlPrefix + "/oepski.PhaseEffect";
        };

        return PhaseEffect;
    })();

    oepski.AnswerMessage = (function() {

        /**
         * Properties of an AnswerMessage.
         * @memberof oepski
         * @interface IAnswerMessage
         * @property {string|null} [comments] AnswerMessage comments
         * @property {oepski.TurnShape|null} [turnShape] AnswerMessage turnShape
         * @property {Array.<oepski.IPhaseEffect>|null} [effects] AnswerMessage effects
         * @property {Array.<oepski.Indication>|null} [indications] AnswerMessage indications
         * @property {Array.<string>|null} [causes] AnswerMessage causes
         * @property {Array.<string>|null} [fundamentals] AnswerMessage fundamentals
         * @property {Array.<string>|null} [progressions] AnswerMessage progressions
         */

        /**
         * Constructs a new AnswerMessage.
         * @memberof oepski
         * @classdesc Represents an AnswerMessage.
         * @implements IAnswerMessage
         * @constructor
         * @param {oepski.IAnswerMessage=} [properties] Properties to set
         */
        function AnswerMessage(properties) {
            this.effects = [];
            this.indications = [];
            this.causes = [];
            this.fundamentals = [];
            this.progressions = [];
            if (properties)
                for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                    if (properties[keys[i]] != null)
                        this[keys[i]] = properties[keys[i]];
        }

        /**
         * AnswerMessage comments.
         * @member {string} comments
         * @memberof oepski.AnswerMessage
         * @instance
         */
        AnswerMessage.prototype.comments = "";

        /**
         * AnswerMessage turnShape.
         * @member {oepski.TurnShape} turnShape
         * @memberof oepski.AnswerMessage
         * @instance
         */
        AnswerMessage.prototype.turnShape = 0;

        /**
         * AnswerMessage effects.
         * @member {Array.<oepski.IPhaseEffect>} effects
         * @memberof oepski.AnswerMessage
         * @instance
         */
        AnswerMessage.prototype.effects = $util.emptyArray;

        /**
         * AnswerMessage indications.
         * @member {Array.<oepski.Indication>} indications
         * @memberof oepski.AnswerMessage
         * @instance
         */
        AnswerMessage.prototype.indications = $util.emptyArray;

        /**
         * AnswerMessage causes.
         * @member {Array.<string>} causes
         * @memberof oepski.AnswerMessage
         * @instance
         */
        AnswerMessage.prototype.causes = $util.emptyArray;

        /**
         * AnswerMessage fundamentals.
         * @member {Array.<string>} fundamentals
         * @memberof oepski.AnswerMessage
         * @instance
         */
        AnswerMessage.prototype.fundamentals = $util.emptyArray;

        /**
         * AnswerMessage progressions.
         * @member {Array.<string>} progressions
         * @memberof oepski.AnswerMessage
         * @instance
         */
        AnswerMessage.prototype.progressions = $util.emptyArray;

        /**
         * Creates a new AnswerMessage instance using the specified properties.
         * @function create
         * @memberof oepski.AnswerMessage
         * @static
         * @param {oepski.IAnswerMessage=} [properties] Properties to set
         * @returns {oepski.AnswerMessage} AnswerMessage instance
         */
        AnswerMessage.create = function create(properties) {
            return new AnswerMessage(properties);
        };

        /**
         * Encodes the specified AnswerMessage message. Does not implicitly {@link oepski.AnswerMessage.verify|verify} messages.
         * @function encode
         * @memberof oepski.AnswerMessage
         * @static
         * @param {oepski.IAnswerMessage} message AnswerMessage message or plain object to encode
         * @param {$protobuf.Writer} [writer] Writer to encode to
         * @returns {$protobuf.Writer} Writer
         */
        AnswerMessage.encode = function encode(message, writer) {
            if (!writer)
                writer = $Writer.create();
            if (message.comments != null && Object.hasOwnProperty.call(message, "comments"))
                writer.uint32(/* id 1, wireType 2 =*/10).string(message.comments);
            if (message.turnShape != null && Object.hasOwnProperty.call(message, "turnShape"))
                writer.uint32(/* id 2, wireType 0 =*/16).int32(message.turnShape);
            if (message.effects != null && message.effects.length)
                for (let i = 0; i < message.effects.length; ++i)
                    $root.oepski.PhaseEffect.encode(message.effects[i], writer.uint32(/* id 3, wireType 2 =*/26).fork()).ldelim();
            if (message.indications != null && message.indications.length) {
                writer.uint32(/* id 4, wireType 2 =*/34).fork();
                for (let i = 0; i < message.indications.length; ++i)
                    writer.int32(message.indications[i]);
                writer.ldelim();
            }
            if (message.causes != null && message.causes.length)
                for (let i = 0; i < message.causes.length; ++i)
                    writer.uint32(/* id 5, wireType 2 =*/42).string(message.causes[i]);
            if (message.fundamentals != null && message.fundamentals.length)
                for (let i = 0; i < message.fundamentals.length; ++i)
                    writer.uint32(/* id 6, wireType 2 =*/50).string(message.fundamentals[i]);
            if (message.progressions != null && message.progressions.length)
                for (let i = 0; i < message.progressions.length; ++i)
                    writer.uint32(/* id 7, wireType 2 =*/58).string(message.progressions[i]);
            return writer;
        };

        /**
         * Encodes the specified AnswerMessage message, length delimited. Does not implicitly {@link oepski.AnswerMessage.verify|verify} messages.
         * @function encodeDelimited
         * @memberof oepski.AnswerMessage
         * @static
         * @param {oepski.IAnswerMessage} message AnswerMessage message or plain object to encode
         * @param {$protobuf.Writer} [writer] Writer to encode to
         * @returns {$protobuf.Writer} Writer
         */
        AnswerMessage.encodeDelimited = function encodeDelimited(message, writer) {
            return this.encode(message, writer).ldelim();
        };

        /**
         * Decodes an AnswerMessage message from the specified reader or buffer.
         * @function decode
         * @memberof oepski.AnswerMessage
         * @static
         * @param {$protobuf.Reader|Uint8Array} reader Reader or buffer to decode from
         * @param {number} [length] Message length if known beforehand
         * @returns {oepski.AnswerMessage} AnswerMessage
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        AnswerMessage.decode = function decode(reader, length) {
            if (!(reader instanceof $Reader))
                reader = $Reader.create(reader);
            let end = length === undefined ? reader.len : reader.pos + length, message = new $root.oepski.AnswerMessage();
            while (reader.pos < end) {
                let tag = reader.uint32();
                switch (tag >>> 3) {
                case 1: {
                        message.comments = reader.string();
                        break;
                    }
                case 2: {
                        message.turnShape = reader.int32();
                        break;
                    }
                case 3: {
                        if (!(message.effects && message.effects.length))
                            message.effects = [];
                        message.effects.push($root.oepski.PhaseEffect.decode(reader, reader.uint32()));
                        break;
                    }
                case 4: {
                        if (!(message.indications && message.indications.length))
                            message.indications = [];
                        if ((tag & 7) === 2) {
                            let end2 = reader.uint32() + reader.pos;
                            while (reader.pos < end2)
                                message.indications.push(reader.int32());
                        } else
                            message.indications.push(reader.int32());
                        break;
                    }
                case 5: {
                        if (!(message.causes && message.causes.length))
                            message.causes = [];
                        message.causes.push(reader.string());
                        break;
                    }
                case 6: {
                        if (!(message.fundamentals && message.fundamentals.length))
                            message.fundamentals = [];
                        message.fundamentals.push(reader.string());
                        break;
                    }
                case 7: {
                        if (!(message.progressions && message.progressions.length))
                            message.progressions = [];
                        message.progressions.push(reader.string());
                        break;
                    }
                default:
                    reader.skipType(tag & 7);
                    break;
                }
            }
            return message;
        };

        /**
         * Decodes an AnswerMessage message from the specified reader or buffer, length delimited.
         * @function decodeDelimited
         * @memberof oepski.AnswerMessage
         * @static
         * @param {$protobuf.Reader|Uint8Array} reader Reader or buffer to decode from
         * @returns {oepski.AnswerMessage} AnswerMessage
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        AnswerMessage.decodeDelimited = function decodeDelimited(reader) {
            if (!(reader instanceof $Reader))
                reader = new $Reader(reader);
            return this.decode(reader, reader.uint32());
        };

        /**
         * Verifies an AnswerMessage message.
         * @function verify
         * @memberof oepski.AnswerMessage
         * @static
         * @param {Object.<string,*>} message Plain object to verify
         * @returns {string|null} `null` if valid, otherwise the reason why it is not
         */
        AnswerMessage.verify = function verify(message) {
            if (typeof message !== "object" || message === null)
                return "object expected";
            if (message.comments != null && message.hasOwnProperty("comments"))
                if (!$util.isString(message.comments))
                    return "comments: string expected";
            if (message.turnShape != null && message.hasOwnProperty("turnShape"))
                switch (message.turnShape) {
                default:
                    return "turnShape: enum value expected";
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    break;
                }
            if (message.effects != null && message.hasOwnProperty("effects")) {
                if (!Array.isArray(message.effects))
                    return "effects: array expected";
                for (let i = 0; i < message.effects.length; ++i) {
                    let error = $root.oepski.PhaseEffect.verify(message.effects[i]);
                    if (error)
                        return "effects." + error;
                }
            }
            if (message.indications != null && message.hasOwnProperty("indications")) {
                if (!Array.isArray(message.indications))
                    return "indications: array expected";
                for (let i = 0; i < message.indications.length; ++i)
                    switch (message.indications[i]) {
                    default:
                        return "indications: enum value[] expected";
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                        break;
                    }
            }
            if (message.causes != null && message.hasOwnProperty("causes")) {
                if (!Array.isArray(message.causes))
                    return "causes: array expected";
                for (let i = 0; i < message.causes.length; ++i)
                    if (!$util.isString(message.causes[i]))
                        return "causes: string[] expected";
            }
            if (message.fundamentals != null && message.hasOwnProperty("fundamentals")) {
                if (!Array.isArray(message.fundamentals))
                    return "fundamentals: array expected";
                for (let i = 0; i < message.fundamentals.length; ++i)
                    if (!$util.isString(message.fundamentals[i]))
                        return "fundamentals: string[] expected";
            }
            if (message.progressions != null && message.hasOwnProperty("progressions")) {
                if (!Array.isArray(message.progressions))
                    return "progressions: array expected";
                for (let i = 0; i < message.progressions.length; ++i)
                    if (!$util.isString(message.progressions[i]))
                        return "progressions: string[] expected";
            }
            return null;
        };

        /**
         * Creates an AnswerMessage message from a plain object. Also converts values to their respective internal types.
         * @function fromObject
         * @memberof oepski.AnswerMessage
         * @static
         * @param {Object.<string,*>} object Plain object
         * @returns {oepski.AnswerMessage} AnswerMessage
         */
        AnswerMessage.fromObject = function fromObject(object) {
            if (object instanceof $root.oepski.AnswerMessage)
                return object;
            let message = new $root.oepski.AnswerMessage();
            if (object.comments != null)
                message.comments = String(object.comments);
            switch (object.turnShape) {
            default:
                if (typeof object.turnShape === "number") {
                    message.turnShape = object.turnShape;
                    break;
                }
                break;
            case "UNSPECIFIED":
            case 0:
                message.turnShape = 0;
                break;
            case "C_SHAPE":
            case 1:
                message.turnShape = 1;
                break;
            case "S_SHAPE":
            case 2:
                message.turnShape = 2;
                break;
            case "J_SHAPE":
            case 3:
                message.turnShape = 3;
                break;
            case "Z_SHAPE":
            case 4:
                message.turnShape = 4;
                break;
            }
            if (object.effects) {
                if (!Array.isArray(object.effects))
                    throw TypeError(".oepski.AnswerMessage.effects: array expected");
                message.effects = [];
                for (let i = 0; i < object.effects.length; ++i) {
                    if (typeof object.effects[i] !== "object")
                        throw TypeError(".oepski.AnswerMessage.effects: object expected");
                    message.effects[i] = $root.oepski.PhaseEffect.fromObject(object.effects[i]);
                }
            }
            if (object.indications) {
                if (!Array.isArray(object.indications))
                    throw TypeError(".oepski.AnswerMessage.indications: array expected");
                message.indications = [];
                for (let i = 0; i < object.indications.length; ++i)
                    switch (object.indications[i]) {
                    default:
                        if (typeof object.indications[i] === "number") {
                            message.indications[i] = object.indications[i];
                            break;
                        }
                    case "UNSPECIFIED":
                    case 0:
                        message.indications[i] = 0;
                        break;
                    case "lackOfAnkleFlex":
                    case 1:
                        message.indications[i] = 1;
                        break;
                    case "tooMuchKneeFlex":
                    case 2:
                        message.indications[i] = 2;
                        break;
                    case "armsBack":
                    case 3:
                        message.indications[i] = 3;
                        break;
                    case "tooMuchHipFlex":
                    case 4:
                        message.indications[i] = 4;
                        break;
                    case "inwardLean":
                    case 5:
                        message.indications[i] = 5;
                        break;
                    case "lossOfEdgeOnOutsideSki":
                    case 6:
                        message.indications[i] = 6;
                        break;
                    case "skiddingOut":
                    case 7:
                        message.indications[i] = 7;
                        break;
                    case "lowInsideHand":
                    case 8:
                        message.indications[i] = 8;
                        break;
                    case "upperBodyTurnsFirst":
                    case 9:
                        message.indications[i] = 9;
                        break;
                    case "turningWithHipsOrShoulders":
                    case 10:
                        message.indications[i] = 10;
                        break;
                    case "upperBodyMatchesSkiDirection":
                    case 11:
                        message.indications[i] = 11;
                        break;
                    case "crossingOutsideHandInFrontOfTheBody":
                    case 12:
                        message.indications[i] = 12;
                        break;
                    case "narrowStance":
                    case 13:
                        message.indications[i] = 13;
                        break;
                    }
            }
            if (object.causes) {
                if (!Array.isArray(object.causes))
                    throw TypeError(".oepski.AnswerMessage.causes: array expected");
                message.causes = [];
                for (let i = 0; i < object.causes.length; ++i)
                    message.causes[i] = String(object.causes[i]);
            }
            if (object.fundamentals) {
                if (!Array.isArray(object.fundamentals))
                    throw TypeError(".oepski.AnswerMessage.fundamentals: array expected");
                message.fundamentals = [];
                for (let i = 0; i < object.fundamentals.length; ++i)
                    message.fundamentals[i] = String(object.fundamentals[i]);
            }
            if (object.progressions) {
                if (!Array.isArray(object.progressions))
                    throw TypeError(".oepski.AnswerMessage.progressions: array expected");
                message.progressions = [];
                for (let i = 0; i < object.progressions.length; ++i)
                    message.progressions[i] = String(object.progressions[i]);
            }
            return message;
        };

        /**
         * Creates a plain object from an AnswerMessage message. Also converts values to other types if specified.
         * @function toObject
         * @memberof oepski.AnswerMessage
         * @static
         * @param {oepski.AnswerMessage} message AnswerMessage
         * @param {$protobuf.IConversionOptions} [options] Conversion options
         * @returns {Object.<string,*>} Plain object
         */
        AnswerMessage.toObject = function toObject(message, options) {
            if (!options)
                options = {};
            let object = {};
            if (options.arrays || options.defaults) {
                object.effects = [];
                object.indications = [];
                object.causes = [];
                object.fundamentals = [];
                object.progressions = [];
            }
            if (options.defaults) {
                object.comments = "";
                object.turnShape = options.enums === String ? "UNSPECIFIED" : 0;
            }
            if (message.comments != null && message.hasOwnProperty("comments"))
                object.comments = message.comments;
            if (message.turnShape != null && message.hasOwnProperty("turnShape"))
                object.turnShape = options.enums === String ? $root.oepski.TurnShape[message.turnShape] === undefined ? message.turnShape : $root.oepski.TurnShape[message.turnShape] : message.turnShape;
            if (message.effects && message.effects.length) {
                object.effects = [];
                for (let j = 0; j < message.effects.length; ++j)
                    object.effects[j] = $root.oepski.PhaseEffect.toObject(message.effects[j], options);
            }
            if (message.indications && message.indications.length) {
                object.indications = [];
                for (let j = 0; j < message.indications.length; ++j)
                    object.indications[j] = options.enums === String ? $root.oepski.Indication[message.indications[j]] === undefined ? message.indications[j] : $root.oepski.Indication[message.indications[j]] : message.indications[j];
            }
            if (message.causes && message.causes.length) {
                object.causes = [];
                for (let j = 0; j < message.causes.length; ++j)
                    object.causes[j] = message.causes[j];
            }
            if (message.fundamentals && message.fundamentals.length) {
                object.fundamentals = [];
                for (let j = 0; j < message.fundamentals.length; ++j)
                    object.fundamentals[j] = message.fundamentals[j];
            }
            if (message.progressions && message.progressions.length) {
                object.progressions = [];
                for (let j = 0; j < message.progressions.length; ++j)
                    object.progressions[j] = message.progressions[j];
            }
            return object;
        };

        /**
         * Converts this AnswerMessage to JSON.
         * @function toJSON
         * @memberof oepski.AnswerMessage
         * @instance
         * @returns {Object.<string,*>} JSON object
         */
        AnswerMessage.prototype.toJSON = function toJSON() {
            return this.constructor.toObject(this, $protobuf.util.toJSONOptions);
        };

        /**
         * Gets the default type url for AnswerMessage
         * @function getTypeUrl
         * @memberof oepski.AnswerMessage
         * @static
         * @param {string} [typeUrlPrefix] your custom typeUrlPrefix(default "type.googleapis.com")
         * @returns {string} The default type url
         */
        AnswerMessage.getTypeUrl = function getTypeUrl(typeUrlPrefix) {
            if (typeUrlPrefix === undefined) {
                typeUrlPrefix = "type.googleapis.com";
            }
            return typeUrlPrefix + "/oepski.AnswerMessage";
        };

        return AnswerMessage;
    })();

    return oepski;
})();

export { $root as default };
