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

    oepski.AnswerMessage = (function() {

        /**
         * Properties of an AnswerMessage.
         * @memberof oepski
         * @interface IAnswerMessage
         * @property {string|null} [comments] AnswerMessage comments
         * @property {oepski.TurnShape|null} [turnShape] AnswerMessage turnShape
         * @property {string|null} [comments2] AnswerMessage comments2
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
         * AnswerMessage comments2.
         * @member {string} comments2
         * @memberof oepski.AnswerMessage
         * @instance
         */
        AnswerMessage.prototype.comments2 = "";

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
            if (message.comments2 != null && Object.hasOwnProperty.call(message, "comments2"))
                writer.uint32(/* id 3, wireType 2 =*/26).string(message.comments2);
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
                        message.comments2 = reader.string();
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
            if (message.comments2 != null && message.hasOwnProperty("comments2"))
                if (!$util.isString(message.comments2))
                    return "comments2: string expected";
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
            if (object.comments2 != null)
                message.comments2 = String(object.comments2);
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
            if (options.defaults) {
                object.comments = "";
                object.turnShape = options.enums === String ? "UNSPECIFIED" : 0;
                object.comments2 = "";
            }
            if (message.comments != null && message.hasOwnProperty("comments"))
                object.comments = message.comments;
            if (message.turnShape != null && message.hasOwnProperty("turnShape"))
                object.turnShape = options.enums === String ? $root.oepski.TurnShape[message.turnShape] === undefined ? message.turnShape : $root.oepski.TurnShape[message.turnShape] : message.turnShape;
            if (message.comments2 != null && message.hasOwnProperty("comments2"))
                object.comments2 = message.comments2;
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
