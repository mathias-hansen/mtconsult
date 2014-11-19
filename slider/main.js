(function (Polymer) {
    'use strict';

    var self,
        e

    new Polymer('slider-component', {
        ready: function () {
            this.images = Array.prototype.slice.call(this.querySelectorAll('img'));
            self = this;
            
            if (!this.start && parseInt(this.start, 10) !== 0) {
                this.start = 0;
                this.current = parseInt(this.start, 10);
            }

            var container = this.$.container;

            for (var img in this.images) {
                var currentImg = parseInt(img, 10);

                if (currentImg === this.current) {
                    this.images[currentImg].classList.add('show');
                }

                this.images[currentImg].classList.add('slider-img');

                container.appendChild(this.images[img]);
            }
            window.setInterval(function () {
                document.querySelector('slider-component').autoSlide();
            }, 5000);
            
        },

        slide: function (evt) {
            var next = evt.target.dataset.img;
            this.current = parseInt(this.current, 10);
            switch (next) {
                case 'left':
                    this.images[this.current].classList.remove('show');
                    this.current = this.current === 0 ? this.images.length - 1 : this.current - 1;
                    this.images[this.current].classList.add('show');
                    break;
                case 'right':
                    this.images[this.current].classList.remove('show');
                    this.current = this.current === this.images.length - 1 ? 0 : this.current + 1;
                    this.images[this.current].classList.add('show');
                    break;
                default:
                    this.images[this.current].classList.remove('show');
                    this.current = next;
                    this.images[this.current].classList.add('show');
                    break;
            }
            this.applyAccent();


        },

        autoSlide: function () {
            this.images[this.current].classList.remove('show');
            this.current = this.current === this.images.length - 1 ? 0 : this.current + 1;
            this.images[this.current].classList.add('show');
        },

        applyAccent: function () {
            //
        }
    });

})(window.Polymer);
