/** Our wonderfull little clock **/
class Clock {
    /**
     * Clock initialization
     */
    constructor() {
        this.hourHand = document.querySelector(".hour.hand");
        this.minuteHand = document.querySelector(".minute.hand");
        this.secondHand = document.querySelector(".second.hand");
        this.timer();

        setInterval(() => this.timer(), 1000);
    }

    /**
     * Timer of the clock
     */
    timer() {
        this.sethandRotation("hour");
        this.sethandRotation("minute");
        this.sethandRotation("second");
    }

    /**
     * Changes the rotation of the hands of the clock
     * @param  {HTMLElement} hand   One of the hand of the clock
     * @param  {number}      degree degree of rotation of the hand
     */
    sethandRotation(hand) {
        let date = new Date(),
            hours,
            minutes,
            seconds,
            percentage,
            degree;

        switch (hand) {
            case "hour":
                hours = date.getHours();
                hand = this.hourHand;
                percentage = this.numberToPercentage(hours, 12);
                break;
            case "minute":
                minutes = date.getMinutes();
                hand = this.minuteHand;
                percentage = this.numberToPercentage(minutes, 60);
                break;
            case "second":
                seconds = date.getSeconds();
                hand = this.secondHand;
                percentage = this.numberToPercentage(seconds, 60);
                break;
        }

        degree = this.percentageToDegree(percentage);
        hand.style.transform = `rotate(${degree}deg) translate(-50%, -50%)`;
    }

    /**
     * Converting a number to a percentage
     * @param  {number} number Number
     * @param  {number} max    Maximum value of the number
     * @return {number}        Return a percentage
     */
    numberToPercentage(number = 0, max = 60) {
        return number / max * 100;
    }

    /**
     * Converting a percentage to a degree
     * @param  {number} percentage Percentage
     * @return {number}            Return a degree
     */
    percentageToDegree(percentage = 0) {
        return percentage * 360 / 100;
    }
}

let clock = new Clock();