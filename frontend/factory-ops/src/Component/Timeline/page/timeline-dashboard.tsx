import moment from "moment";
import React from "react";
import Timeline, {TimelineItemBase } from 'react-calendar-timeline'
import "react-calendar-timeline/lib/Timeline.css";

const TimelineDashboard = () =>
{
	const groups : TimelineGroup[] = [{id: 1, title:'group'}, {id: 2, title:'group2'}]
	const items: TimelineItemBase<Date>[] = [
		{
			id: 'item1',
			group: '1',
			title: 'zadanie 1',
			start_time: moment().startOf("day").toDate(),
			end_time: moment().startOf("day").add(1,"hour").toDate(),
		},
		{
			id: 'item2',
			group: '2',
			start_time: moment().startOf("day").toDate(),
			end_time: moment().startOf("day").add(1,"hour").toDate(),
		},
		
	]

	return (
		<Timeline
			groups={groups}
			items={items}
			defaultTimeStart={moment().add(-1,'day')}
			defaultTimeEnd={moment().add(2,'day')}
			canMove={true}
			canResize={'both'}
      ></Timeline>
	)
}

export default TimelineDashboard

interface TimelineGroup {
	id: number,
	title: string
}
