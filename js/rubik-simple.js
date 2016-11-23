var FACES = {
    front: { M: "yellow", p: "yellow", P: "orange", m: "white", CF: "green", o: "orange", N: "blue", n: "white", O: "orange" },
    back: { G: "blue", f: "blue", F: "red", g: "yellow", CB: "blue", e: "red", H: "red", h: "orange", E: "orange" },
    up: { C: "yellow", b: "white", B: "blue", c: "orange", CU: "white", a: "blue", D: "white", d: "green", A: "orange", },
    down: { U: "green", x: "red", X: "green", u: "blue", CD: "yellow", w: "green", V: "white", v: "red", W: "green", },
    left: { I: "green", l: "green", L: "white", i: "green", CL: "orange", k: "yellow", J: "red", j: "blue", K: "yellow", },
    right: { Q: "yellow", t: "orange", T: "blue", q: "yellow", CR: "red", s: "white", R: "red", r: "red", S: "white", }
};

YUI.add('rubik-simple', function(Y) {
    /*
    *
    */
    var CUBIE_MOVEMENTS = {
        'LM-left': {
            "utl": "btl", "ucl": "bcl", "ubl": "bbl", "ftl": "utl", "fcl": "ucl", "fbl": "ubl", "dtl": "ftl",
            "dcl": "fcl", "dbl": "fbl", "btl": "dtl", "bcl": "dcl", "bbl": "dbl", "ltl": "lbl", "lcl": "lbc",
            "lbl": "lbr", "ltc": "lcl", "lbc": "lcr", "ltr": "ltl", "lcr": "ltc", "lbr": "ltr", "lcc": "lcc"
        },
        "LM-right": {
            "utl": "ftl", "ucl": "fcl", "ubl": "fbl", "ftl": "dtl", "fcl": "dcl", "fbl": "dbl", "dtl": "btl",
            "dcl": "bcl", "dbl": "bbl", "btl": "utl", "bcl": "ucl", "bbl": "ubl", "ltl": "ltr", "lcl": "ltc",
            "lbl": "ltl", "ltc": "lcr", "lbc": "lcl", "ltr": "lbr", "lcr": "lbc", "lbr": "lbl", "lcc": "lcc"
        },
        'RM-right': {
            "utr": "ftr", "ucr": "fcr", "ubr": "fbr", "ftr": "dtr", "fcr": "dcr", "fbr": "dbr", "dtr": "btr",
            "dcr": "bcr", "dbr": "bbr", "btr": "utr", "bcr": "ucr", "bbr": "ubr", "rtl": "rbl", "rcl": "rbc",
            "rbl": "rbr", "rtc": "rcl", "rcc": "rcc", "rbc": "rcr", "rtr": "rtl", "rcr": "rtc", "rbr": "rtr"
        },
        'RM-left': {
            "utr": "btr", "ucr": "bcr", "ubr": "bbr", "ftr": "utr", "fcr": "ucr", "fbr": "ubr", "dtr": "ftr",
            "dcr": "fcr", "dbr": "fbr", "btr": "dtr", "bcr": "dcr", "bbr": "dbr", "rtl": "rtr", "rcl": "rtc",
            "rbl": "rtl", "rtc": "rcr", "rbc": "rcl", "rtr": "rbr", "rcr": "rbc", "rbr": "rbl", "rcc": "rcc"
        },
        'CM-right': {
            "utc": "ftc", "ucc": "fcc", "ubc": "fbc", "ftc": "dtc",
            "fcc": "dcc", "fbc": "dbc", "dtc": "btc", "dcc": "bcc",
            "dbc": "bbc", "btc": "utc", "bcc": "ucc", "bbc": "ubc"
        },
        'CM-left': {
            "utc": "btc", "ucc": "bcc", "ubc": "bbc", "ftc": "utc",
            "fcc": "ucc", "fbc": "ubc", "dtc": "ftc", "dcc": "fcc",
            "dbc": "fbc", "btc": "dtc", "bcc": "dcc", "bbc": "dbc"
        },
        'UE-left': {
            "rtl": "ftl", "rtc": "ftc", "rtr": "ftr", "ftl": "ltl", "ftc": "ltc", "ftr": "ltr", "ltl": "bbr",
            "ltc": "bbc", "ltr": "bbl", "bbr": "rtl", "bbc": "rtc", "bbl": "rtr", "utl": "utr", "ucl": "utc",
            "ubl": "utl", "utc": "ucr", "ubc": "ucl", "utr": "ubr", "ucr": "ubc", "ubr": "ubl", "ucc": "ucc"
        },
        'UE-right': {
            "ltl": "ftl", "ltc": "ftc", "ltr": "ftr", "ftl": "rtl", "ftc": "rtc", "ftr": "rtr", "rtl": "bbr",
            "rtc": "bbc", "rtr": "bbl", "bbr": "ltl", "bbc": "ltc", "bbl": "ltr", "utl": "ubl", "ucl": "ubc",
            "ubl": "ubr", "utc": "ucl", "ucc": "ucc", "ubc": "ucr", "utr": "utl", "ucr": "utc", "ubr": "utr"
        },
        'CE-right': {
            "fcl": "rcl", "fcc": "rcc", "fcr": "rcr", "lcl": "fcl",
            "lcc": "fcc", "lcr": "fcr", "bcl": "lcr", "bcc": "lcc",
            "bcr": "lcl", "rcl": "bcr", "rcc": "bcc", "rcr": "bcl"
        },
        'CE-left': {
            "fcl": "lcl", "fcc": "lcc", "fcr": "lcr", "rcl": "fcl",
            "rcc": "fcc", "rcr": "fcr", "bcl": "rcr", "bcc": "rcc",
            "bcr": "rcl", "lcl": "bcr", "lcc": "bcc", "lcr": "bcl"
        },
        'DE-left': {
            "fbl": "lbl", "fbc": "lbc", "fbr": "lbr", "lbl": "btr", "lbc": "btc", "lbr": "btl", "btr": "rbl",
            "btc": "rbc", "btl": "rbr", "rbl": "fbl", "rbc": "fbc", "rbr": "fbr", "dtl": "dbl", "dcl": "dbc",
            "dbl": "dbr", "dtc": "dcl", "dcc": "dcc", "dbc": "dcr", "dtr": "dtl", "dcr": "dtc", "dbr": "dtr"
        },
        'DE-right': {
            "fbl": "rbl", "fbc": "rbc", "fbr": "rbr", "rbl": "btr", "rbc": "btc", "rbr": "btl", "btr": "lbl",
            "btc": "lbc", "btl": "lbr", "lbl": "fbl", "lbc": "fbc", "lbr": "fbr", "dtl": "dtr", "dcl": "dtc",
            "dbl": "dtl", "dtc": "dcr", "dbc": "dcl", "dtr": "dbr", "dcr": "dbc", "dbr": "dbl", "dcc": "dcc"
        },
        'FS-left': {
            "ubl": "lbr", "ubc": "lcr", "ubr": "ltr", "lbr": "dtr", "lcr": "dtc", "ltr": "dtl", "dtl": "rbl",
            "dtc": "rcl", "dtr": "rtl", "rbl": "ubr", "rcl": "ubc", "rtl": "ubl", "ftl": "fbl", "fcl": "fbc",
            "fbl": "fbr", "ftc": "fcl", "fcc": "fcc", "fbc": "fcr", "ftr": "ftl", "fcr": "ftc", "fbr": "ftr"
        },
        'FS-right': {
            "ubl": "rtl", "ubc": "rcl", "ubr": "rbl", "lbr": "ubl", "lcr": "ubc", "ltr": "ubr", "dtl": "ltr",
            "dtc": "lcr", "dtr": "lbr", "rbl": "dtl", "rcl": "dtc", "rtl": "dtr", "ftl": "ftr", "fcl": "ftc",
            "fbl": "ftl", "ftc": "fcr", "fbc": "fcl", "ftr": "fbr", "fcr": "fbc", "fbr": "fbl", "fcc": "fcc"

        },
        'CS-left': {
            "ucl": "lbc", "ucc": "lcc", "ucr": "ltc", "ltc": "dcl",
            "lcc": "dcc", "lbc": "dcr", "dcl": "rbc", "dcc": "rcc",
            "dcr": "rtc", "rbc": "ucr", "rcc": "ucc", "rtc": "ucl"

        },
        'CS-right': {
            "lbc": "ucl", "lcc": "ucc", "ltc": "ucr", "dcl": "ltc",
            "dcc": "lcc", "dcr": "lbc", "rbc": "dcl", "rcc": "dcc",
            "rtc": "dcr", "ucr": "rbc", "ucc": "rcc", "ucl": "rtc"
        },
        'BS-right': {
            "utl": "rtr", "utc": "rcr", "utr": "rbr", "rtr": "dbr", "rcr": "dbc", "rbr": "dbl", "dbr": "lbl",
            "dbc": "lcl", "dbl": "ltl", "lbl": "utl", "lcl": "utc", "ltl": "utr", "btl": "bbl", "bcl": "bbc",
            "bbl": "bbr", "btc": "bcl", "bcc": "bcc", "bbc": "bcr", "btr": "btl", "bcr": "btc", "bbr": "btr"
        },
        'BS-left': {
            "rtr": "utl", "rcr": "utc", "rbr": "utr", "dbr": "rtr", "dbc": "rcr", "dbl": "rbr", "lbl": "dbr",
            "lcl": "dbc", "ltl": "dbl", "utl": "lbl", "utc": "lcl", "utr": "ltl", "btl": "btr", "bcl": "btc",
            "bbl": "btl", "btc": "bcr", "bbc": "bcl", "btr": "bbr", "bcr": "bbc", "bbr": "bbl", "bcc": "bcc"
        }
    };

    //Asigna las clases de css correspondientes a cada cara 
    var INIT_CONFIG = {
        "front": ["ftl", "fcl", "fbl", "ftc", "fcc", "fbc", "ftr", "fcr", "fbr"],
        "back": ["btl", "bcl", "bbl", "btc", "bcc", "bbc", "btr", "bcr", "bbr"],
        "up": ["utl", "ucl", "ubl", "utc", "ucc", "ubc", "utr", "ucr", "ubr"],
        "down": ["dtl", "dcl", "dbl", "dtc", "dcc", "dbc", "dtr", "dcr", "dbr"],
        "left": ["ltl", "lcl", "lbl", "ltc", "lcc", "lbc", "ltr", "lcr", "lbr"],
        "right": ["rtl", "rcl", "rbl", "rtc", "rcc", "rbc", "rtr", "rcr", "rbr"]
    };

    function Rubik(cfg) {
        this._init(cfg || {});
        this._bind();
        this._setInitialPosition(cfg);
    }
    Rubik.prototype = {
        _init: function(cfg) {
            this._container = Y.one(cfg.container || '#cube-container');
            this._cube = Y.one(cfg.src || '#cube');
            this._plane = Y.Node.create('<div id="plane"></div>');
            this._cube.append(this._plane);
            this._expectingTransition = false;
            this._setScroll();
        },
        /*
        * We use the YUI gesture which allows to abstract the click/tap
        * so it works with the mouse click or with tap/flick gestures.
        */
        _bind: function() {
            //TODO: Fix YUI bug to abstract transitionEnd
            this._cube.on('transitionend', this._endTransition, this);
            this._cube.on('webkitTransitionEnd', this._endTransition, this);

            this._container.on('gesturemovestart', this._onTouchCube, { preventDefault: true }, this);
            this._container.on('gesturemove', this._onMoveCube, { preventDefault: true }, this);
            this._container.on('gesturemoveend', this._onEndCube, { preventDefault: true }, this);

            this._container.on('gesturestart', this._multiTouchStart, this);
            this._container.on('gesturechange', this._multiTouchMove, this);
            this._container.on('gestureend', this._multiTouchEnd, this);

            Y.one('body').on('gesturemovestart', this._checkScroll, {}, this);
        },
        _setScroll: function(evt) {
            self = this;
            setTimeout(function() {
                window.scrollTo(0, 1);
            }, 1);
        },
        _setInitialPosition: function(cfg) {
            this._setInitialColors();
            //TODO: set as a configurable ATTR on instanciation
            var pos = cfg && cfg.position || { x: 28, y: -28 };
            this._cube.setStyle('transform', 'rotateX(' + pos.y + 'deg) rotateY(' + pos.x + 'deg)');
            this._cubeXY = pos;
            this._tempXY = pos;
        },
        _setInitialColors: function() {
            for (var face in INIT_CONFIG) {
                var faceArr = [];
                for (var key in FACES[face]) {
                    faceArr.push(FACES[face][key]);
                }
                Y.one('.' + INIT_CONFIG[face][0] + '.' + face + ' > div').addClass(faceArr[0]);
                Y.one('.' + INIT_CONFIG[face][1] + '.' + face + ' > div').addClass(faceArr[1]);
                Y.one('.' + INIT_CONFIG[face][2] + '.' + face + ' > div').addClass(faceArr[2]);
                Y.one('.' + INIT_CONFIG[face][3] + '.' + face + ' > div').addClass(faceArr[3]);
                Y.one('.' + INIT_CONFIG[face][4] + '.' + face + ' > div').addClass(faceArr[4]);
                Y.one('.' + INIT_CONFIG[face][5] + '.' + face + ' > div').addClass(faceArr[5]);
                Y.one('.' + INIT_CONFIG[face][6] + '.' + face + ' > div').addClass(faceArr[6]);
                Y.one('.' + INIT_CONFIG[face][7] + '.' + face + ' > div').addClass(faceArr[7]);
                Y.one('.' + INIT_CONFIG[face][8] + '.' + face + ' > div').addClass(faceArr[8]);
            }
        },
        _endTransition: function(evt) {
            if (this._expectingTransition) {
                evt.halt();
                this._plane.set('className', "");
                this._reorganizeCubies();
                this._detachToPlane();
                this._moving = false;
                this._expectingTransition = false;
            }
        },
        /*
        * We got the first finger/click on the cube
        * Save the position.
        */
        _onTouchCube: function(evt) {
            evt.halt();
            this._tempCubie = evt.target.ancestor('.cubie');
            this._startX = evt.clientX;
            this._startY = evt.clientY;
            this._deltaX = 0;
            this._deltaY = 0;
        },
        /*
        * Getting a mouse/double-finger moving. We need to update the rotation(XY) of the cube
        * We need to add some logic due to the mouse.
        * This function gets triggered if a gesture/click is present
        */
        _onMoveCube: function(evt) {
            evt.halt();
            //TODO set rate move as a constant.
            var deltaX = this._deltaX = ((evt.clientX - this._startX) / 1.2),
                deltaY = this._deltaY = ((evt.clientY - this._startY) / 1.2),
                x = this._cubeXY.x + deltaX;
            y = this._cubeXY.y - deltaY;
            if (this._gesture) {
                this._tempXY = { x: x, y: y };
                this._moved = true;
                this._cube.setStyle('transform', 'rotateX(' + y + 'deg) rotateY(' + x + 'deg)');
                Y.one('#log > p').setContent("Moved:" + Math.floor(y) + ' , ' + Math.floor(x));
            } else {
                this._moved = false;
            }
        },
        /*
        * All magic happen here. Check how the user flick his finger, in which side...
        * Map this regarding the 2D position of the cube and transform it in 3D.
        */
        _onEndCube: function(evt) {
            //if gesture we dont do movement
            if (this._gesture || this._moved || !this._tempCubie) {
                this._gesture = false;
                this._moved = false;
                return;
            }
            evt.halt();

            if (!this._deltaX && !this._deltaY) return; // if no delta no move, so nothing to do!

            this._tempXY = { x: this._tempXY.x % 360, y: this._tempXY.y % 360 };// to get controlled the degrees
            var threshold = 70,//ToDo: Double check this value in different devices
                movement, swap, cubeMove
            rotateX = this._deltaX > 0 ? "right" : "left",
                rotateXInverted = rotateX == "right" ? "left" : "right",
                deg = Math.abs(this._tempXY.x),
                rotateY = this._deltaY > 0 ? "right" : "left",
                rotateYInverted = rotateY == "right" ? "left" : "right",
                rotateBoth = Math.abs(this._deltaX) > threshold && Math.abs(this._deltaY) > threshold;
            mHorizontal = Math.abs(this._deltaX) > Math.abs(this._deltaY),
                parts = this._tempCubie.get('className').split(' ');
            this._expectingTransition = true;

            /* We will have to translate the finger movements to the cube movements
            * (implies transform 2D dimension into -> 3D)
            * At some point we should refactor this in a better way...
            */

            switch (true) {
                //E Movements:
                //Front, left, right, back in E (left or right) direction
                case parts[2] != "up" && parts[2] != "down" && mHorizontal:
                    movement = { face: parts[4].charAt(0), slice: parts[4].charAt(1), rotate: rotateX };
                    break;
                //up and down in E ( we have to adjust the 3D rotation tu a 2D plane:
                case (parts[2] == "up" || parts[2] == "down") && mHorizontal && deg >= -45 && deg < 45:
                    if (parts[2] == "down") { swap = rotateX; rotateX = rotateXInverted; rotateXInverted = swap; }
                    movement = { face: parts[5].charAt(0), slice: parts[5].charAt(1), rotate: rotateX };
                    break;

                case (parts[2] == "up" || parts[2] == "down") && mHorizontal && deg >= 45 && deg < 135:
                    if (parts[2] == "down") { swap = rotateX; rotateX = rotateXInverted; rotateXInverted = swap; }
                    movement = { face: parts[3].charAt(0), slice: parts[3].charAt(1), rotate: this._tempXY.x < 0 ? rotateXInverted : rotateX };
                    break;

                case (parts[2] == "up" || parts[2] == "down") && mHorizontal && deg >= 135 && deg < 225:
                    if (parts[2] == "down") { swap = rotateX; rotateX = rotateXInverted; rotateXInverted = swap; }
                    movement = { face: parts[5].charAt(0), slice: parts[5].charAt(1), rotate: rotateXInverted };
                    break;

                case (parts[2] == "up" || parts[2] == "down") && mHorizontal && deg >= 225 && deg < 315:
                    if (parts[2] == "down") { swap = rotateX; rotateX = rotateXInverted; rotateXInverted = swap; }
                    movement = { face: parts[3].charAt(0), slice: parts[3].charAt(1), rotate: this._tempXY.x < 0 ? rotateX : rotateXInverted };
                    break;

                //M movements:

                //front and back
                case (parts[2] == "front" || parts[2] == "back") && !mHorizontal:
                    if (parts[2] == "back") { swap = rotateY; rotateY = rotateYInverted; rotateYInverted = swap; }
                    movement = { face: parts[3].charAt(0), slice: parts[3].charAt(1), rotate: rotateY };
                    break;
                //right and left
                case (parts[2] == "right" || parts[2] == "left") && !mHorizontal:
                    if (parts[2] == "left") { swap = rotateY; rotateY = rotateYInverted; rotateYInverted = swap; }
                    movement = { face: parts[5].charAt(0), slice: parts[5].charAt(1), rotate: rotateY };
                    break;
                //up & down:
                case (parts[2] == "up" || parts[2] == "down") && !mHorizontal && deg >= -45 && deg < 45:
                    movement = { face: parts[3].charAt(0), slice: parts[3].charAt(1), rotate: rotateY };
                    break;

                case (parts[2] == "up" || parts[2] == "down") && !mHorizontal && deg >= 45 && deg < 135:
                    movement = { face: parts[5].charAt(0), slice: parts[5].charAt(1), rotate: rotateYInverted };
                    break;

                case (parts[2] == "up" || parts[2] == "down") && !mHorizontal && deg >= 135 && deg < 225:
                    movement = { face: parts[3].charAt(0), slice: parts[3].charAt(1), rotate: rotateYInverted };
                    break;

                case (parts[2] == "up" || parts[2] == "down") && !mHorizontal && deg >= 225 && deg < 315:
                    movement = { face: parts[5].charAt(0), slice: parts[5].charAt(1), rotate: rotateY };
                    break;

                default: break;
            }

            cubeMove = getMovementOriginalNotation(movement);

            if (movement && movement.face != "C") {
                this._doMovement(movement);
                $('#movement-lbl').text(cubeMove);
                console.log(cubeMove);
                var arduinoTypeMove = "";
                switch (cubeMove) {
                    case "F": arduinoTypeMove = "F"; break;
                    case "F'": arduinoTypeMove = "f"; break;
                    case "R": arduinoTypeMove = "R"; break;
                    case "R'": arduinoTypeMove = "r"; break;
                    case "L": arduinoTypeMove = "L"; break;
                    case "L'": arduinoTypeMove = "l"; break;
                    case "U": arduinoTypeMove = "U"; break;
                    case "U'": arduinoTypeMove = "u"; break;
                    case "D": arduinoTypeMove = "D"; break;
                    case "D'": arduinoTypeMove = "d"; break;
                    case "B": arduinoTypeMove = "B"; break;
                    case "B'": arduinoTypeMove = "b"; break;
                    case "F2": arduinoTypeMove = "FF"; break;
                    case "R2": arduinoTypeMove = "RR"; break;
                    case "L2": arduinoTypeMove = "LL"; break;
                    case "U2": arduinoTypeMove = "UU"; break;
                    case "D2": arduinoTypeMove = "DD"; break;
                    case "B2": arduinoTypeMove = "BB"; break;
                    default: break;
                }
                if (typeof Android != "undefined") {
                    Android.sendToArduino(arduinoTypeMove);
                }
            }

        },
        _multiTouchStart: function(evt) {
            evt.halt();
            this._startX = evt.clientX || evt.pageX;
            this._startY = evt.clientY || evt.pageY;
            this._gesture = true;
        },
        _multiTouchMove: function(evt) {
            if (this._portrait || !this._enableRotation) return;

            evt.clientX = evt.pageX;
            evt.clientY = evt.pageY;
            this._onMoveCube(evt);
        },
        _multiTouchEnd: function(evt) {
            this._gesture = false;
            evt.halt();
            this._cubeXY.x = this._tempXY.x;
            this._cubeXY.y = this._tempXY.y;
        },

        _solve: function(moves) {
            console.log('attemp to solve');
            var totalMoves = moves.length;
            var increment = 100 / totalMoves;
            var startTime = new Date();
            var progress = 0;
            var i = 0;
            this._solving = Y.later(330, this, function() {
                this._expectingTransition = true;
                moves[i] && this._doMovement(moves[i], true);
                var endTime = new Date();
                var timeDiff = endTime - startTime;
                timeDiff /= 1000;
                var seconds = Math.round(timeDiff % 60);
                var secondsStr = seconds < 10 ? '0' + seconds.toString() : seconds.toString();
                timeDiff = Math.floor(timeDiff / 60);
                var minutes = Math.round(timeDiff % 60);
                var minutesStr = minutes < 10 ? '0' + minutes.toString() : minutes.toString();
                var timeElapsed = minutesStr + ':' + secondsStr;
                $('#time-lbl').text(timeElapsed);
                $('#movement-lbl').text(getMovementOriginalNotation(moves[i]));
                progress = increment * i + 1;
                progress = progress.toString();
                $('#solve-progress-bar').css('width', progress + '%');
                console.log(i + 1 + ': ' + getMovementOriginalNotation(moves[i]));
                if (i == moves.length - 1) {
                    this._solving.cancel();
                    console.log('Solving finished');
                    $('#solve-progress-bar').css('width', '100%');
                    $('#details-btn').show('clip');
                    console.log('Tiempo: ' + timeElapsed);
                }
                i++;
            }, null, true);
        },

        _doMovement: function(m, fromQueue) {
            var canceledMove = false;
            if (this._moving) {
                console.log('Se cancelo D:');
                if (typeof Android != "undefined") {
                    Android.moveCancelled(getMovementOriginalNotation(m));
                }
                return;//we cancel if there is some movement going on
            }
            var plane = this._plane,
                list = Y.all('.' + m.face + m.slice);
            this._movement = m;
            this._moving = true;
            this._attachToPlane(list);
            plane.addClass('moving').addClass(m.slice + '-' + m.rotate);
        },
        _attachToPlane: function(list) {
            this._plane.setContent(list);
        },
        _detachToPlane: function() {
            var children = this._plane.get('children');
            this._cube.append(children);
        },
        _reorganizeCubies: function() {
            var m = this._movement,
                changes = CUBIE_MOVEMENTS[m.face + m.slice + '-' + m.rotate],
                list = this._plane.get('children'),
                tempCubies = {};
            list.each(function(originCube, i) {
                if (originCube.hasClass('face')) return;
                //get the class and the position of the cubie
                var originCubeClass = originCube.get('className'),
                    cubePos = (originCubeClass.split(' ', 1))[0];
                //we keep te original position and class
                tempCubies[cubePos] = originCubeClass;

                //we try to find the cube to swap position
                var destCube = Y.one('.' + changes[cubePos]);

                // if we dont find it, we already swap that cubie, we have to find the original css class in temp.
                var destCubeClass = destCube ? destCube.get('className') : tempCubies[changes[cubePos]],
                    cubePosDes = destCubeClass.split(' ', 1)[0];

                //swap position of the cubie acording to the movement.
                originCube.set('className', cubePosDes + destCubeClass.substr(3));
            });
        },
        _initLandscape: function() {
            var transformIn = { opacity: 1, duration: 2 },
                css = { display: 'block' };

            this._cube.transition(transformIn);
        },
        run: function() {
            this._initLandscape();
        }
    };
    Y.Rubik = Rubik;
}, "0.0.1", {
        requires: ['yui-later', 'node', 'transition', 'event', 'event-delegate', 'event-gestures']
    });

function getMovementOriginalNotation(movement) {
    var cubeMove;
    if (movement.face == "U") cubeMove = movement.rotate == "left" ? "U" : "U'";
    if (movement.face == "D") cubeMove = movement.rotate == "left" ? "D'" : "D";
    if (movement.face == "R") cubeMove = movement.rotate == "left" ? "R" : "R'";
    if (movement.face == "L") cubeMove = movement.rotate == "left" ? "L'" : "L";
    if (movement.face == "B") cubeMove = movement.rotate == "left" ? "B" : "B'";
    if (movement.face == "F") cubeMove = movement.rotate == "left" ? "F'" : "F";
    return cubeMove;
}